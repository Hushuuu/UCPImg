using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace UCPic
{
    public partial class Form1 : Form
    {
        private List<ImgViewClass> imageList = new();
        private int nowIndex = -1;
        private string imgur_client_id = "";
        private string api_upload_url = "";
        private string api_del_url = "";
        private string local_imglist_json_path = "local_images_save.json";
        private string local_imglist_json_backfolder = "backup";

        public Form1()
        {
            imgur_client_id = ConfigurationManager.AppSettings["imgur_client_id"];
            api_upload_url = ConfigurationManager.AppSettings["api_upload_url"];
            api_del_url = ConfigurationManager.AppSettings["api_del_url"];

            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.Columns.Add("描述", 170);
            listView1.LabelEdit = true;
            linkLabel1.Text = string.Empty;
            textBox1.Text = imgur_client_id;
            textBox1.Visible = false;

        }
        //貼上圖片
        private void button1_Click(object sender, EventArgs e)
        {
            var img = Clipboard.GetImage();
            if (img != null)
            {
                var imgBase64 = CommonHelpers.ImageToBase64(img, ImageFormat.Jpeg);
                pictureBox1.Image = img;
                var ins_serial = imageList.Count == 0 ? 1 : imageList.Select(z => z.serial).Max() + 1;
                var imageObj = new ImgViewClass
                {
                    name = ins_serial.ToString(),
                    serial = ins_serial,
                    img_base64 = CommonHelpers.ImageToBase64(img, ImageFormat.Jpeg)
                };
                imageList.Add(imageObj);

                refreshShowList();
                listView1.Items[imageList.Count - 1].Selected = true;
            }
            else
            {
                //MessageBox.Show("剪貼簿目前沒有圖片");
            }
        }
        /// <summary>
        /// 刷新顯示
        /// </summary>
        private void refreshShowList()
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            this.imageList.ForEach(z =>
            {
                var item = new ListViewItem(z.name);
                listView1.Items.Add(item);
            });
            this.listView1.EndUpdate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (listView1.SelectedIndices.Count > 0)
            {
                var selectIndex = this.listView1.SelectedIndices[0];
                this.pictureBox1.Image?.Dispose();
                this.pictureBox1.Image = CommonHelpers.Base64StringToImage(imageList[selectIndex].img_base64);
                linkLabel1.Text = imageList[selectIndex].upload_url;
                nowIndex = selectIndex;
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }
        //刪除
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                var index = listView1.SelectedIndices[0];
                DelApiFunc(index);
                linkLabel1.Text = string.Empty;
                pictureBox1.Image?.Dispose();
                imageList.RemoveAt(index);
                listView1.Items[index].Remove();
                if (listView1.Items.Count > index)
                {
                    listView1.Items[index].Selected = true;
                    nowIndex = index;
                }
                else
                {
                    var max_last = listView1.Items.Count - 1;
                    if (max_last >= 0)
                        listView1.Items[max_last].Selected = true;
                    nowIndex = max_last;
                }
            }
            if (listView1.Items.Count == 0)
                nowIndex = -1;
        }
        //上傳
        private async void button3_Click(object sender, EventArgs e)
        {
            if (nowIndex > -1)
            {
                if (imageList[nowIndex].upload_url != null)
                {
                    MessageBox.Show("已經上傳過了");
                    return;
                }
                if(textBox1.Text.Length == 0)
                {
                    MessageBox.Show("沒有設定imgur client id");
                    return;
                }

                using var httpClient = new HttpClient();
                using var form = new MultipartFormDataContent();
                /*
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    this.pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }
                // 將圖像資料包裝在StreamContent中
                var imageContent = new StreamContent(new MemoryStream(imageData));
                */

                // 設置Bearer授權標頭
                httpClient.DefaultRequestHeaders.Add("Authorization", "Client-ID " + textBox1.Text);
                form.Add(new StringContent(CommonHelpers.ImageToBase64(pictureBox1.Image, ImageFormat.Jpeg)), "image");

                // 呼叫API並傳送表單數據
                var response = await httpClient.PostAsync(api_upload_url, form);
                // 檢查回應狀態碼
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("上傳成功");
                    var res_str = await response.Content.ReadAsStringAsync();
                    var res_obj = JsonSerializer.Deserialize<ImgurUploadRetClass>(res_str);
                    linkLabel1.Text = res_obj.data.link;
                    imageList[nowIndex].upload_url = res_obj.data.link;
                    imageList[nowIndex].deletehash = res_obj.data.deletehash;
                }
                else
                {
                    var res_str = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(res_str);
                }
            }
            else
            {
                MessageBox.Show("目前無選擇圖片");
            }
        }
        //複製網址
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.linkLabel1.Text) == false)
            {
                Clipboard.Clear();
                Clipboard.SetText(this.linkLabel1.Text);
                MessageBox.Show("複製網址成功");
            }
        }
        //本地載入
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image?.Dispose();
            LoadLocal();
        }
        //本地存檔
        private void button5_Click(object sender, EventArgs e)
        {
            if (imageList.Count > 0)
            {
                var _data = imageList;
                string json = JsonSerializer.Serialize(_data);
                File.WriteAllText(local_imglist_json_path, json);
                if (!Directory.Exists(local_imglist_json_backfolder))
                {
                    Directory.CreateDirectory(local_imglist_json_backfolder);
                }
                var backfile_path = local_imglist_json_backfolder + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json";
                File.WriteAllText(backfile_path, json);
                MessageBox.Show("本地存檔&備份成功");
            }
            else
            {
                MessageBox.Show("目前無圖片");
            }
        }
        //載入本地存檔
        private void LoadLocal()
        {
            if (File.Exists(local_imglist_json_path))
            {
                var str = File.ReadAllText(local_imglist_json_path);
                var data = JsonSerializer.Deserialize<List<ImgViewClass>>(str);
                imageList = data;
                refreshShowList();
                MessageBox.Show("載入成功");
            }
            else
            {
                MessageBox.Show("無本地存檔");
            }
        }
        //放大打開圖片
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            var f = new ImgViewForm(pictureBox1.Image);
            f.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.V) && (e.Modifiers == Keys.Control))
            {
                //ctrl+v
                button1_Click(sender, e);
            }
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var editVal = e.Label;
            if (editVal != imageList[e.Item].name && !string.IsNullOrEmpty(editVal))
            {
                imageList[e.Item].name = editVal;
            }
        }

        //delete api
        private async void DelApiFunc(int index)
        {
            var obj = imageList[index];
            if (!string.IsNullOrEmpty(obj.deletehash))
            {
                try
                {
                    var url = string.Format(api_del_url, obj.deletehash);
                    using var client = new HttpClient();
                    using var request = new HttpRequestMessage(HttpMethod.Delete, url);
                    request.Headers.Add("Authorization", "Client-ID " + textBox1.Text);
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var res_str = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start(new ProcessStartInfo { FileName = ((LinkLabel)sender).Text, UseShellExecute = true });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
        }
    }


}