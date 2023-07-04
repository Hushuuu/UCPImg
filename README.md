# UCPImg

##支援  
 
1.剪貼簿圖片暫時管理  
2.即時上傳imgur且可刪除  

#設定  

development `App.config`  
portable `UCPic.dll.config`

設定imgur 的ClientId

```xml
<add key="imgur_client_id" value="xxxxxxxxx"/>
```

#使用

1.貼上或`ctrl+V`，將剪貼簿圖片貼至程式可上傳至imgur  
2.雙擊圖片放大顯示，ESC關閉顯示  

#存檔

根目錄`/backup/` 底下有存檔的備份  
可透過載入，來將本地清單載入  

#載入

固定載入根目錄下`/local_images_save.json`之檔案  
可以將備份檔更名覆蓋後載入  


