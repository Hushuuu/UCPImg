# UCPImg

##支援  
 
1.剪貼簿圖片暫時管理  
2.即時上傳imgur&可刪除  

#設定檔  

development `App.config`  
portable `UCPic.dll.config`

[建立imgur帳號](https://medium.com/front-end-augustus-study-notes/imgur-api-3a41f2848bb8)  
設定imgur 的ClientId，或在程式內輸入
```xml
<add key="imgur_client_id" value="xxxxxxxxx"/>
```

#使用

1.貼上或`ctrl+V`，剪貼簿圖片貼至程式，可上傳至imgur  
2.雙擊圖片放大顯示，ESC關閉顯示  

#存檔

將清單存到`/local_images_save.json`
根目錄`/backup/` 底下有存檔的備份  

#載入

固定載入根目錄下`/local_images_save.json`
可以將備份檔更名覆蓋後載入  

#api limit注意事項  

每個應用程序每天可允許約`1250`次上傳  
或每天約`12500`次請求  
如果在一個月內觸及每日限額五次  
該應用程序將在該月的其餘時間內被封鎖  
剩餘的信用額度將隨著每個請求的響應  
在`X-RateLimit-ClientRemaining HTTP header`中顯示


