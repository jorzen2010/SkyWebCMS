<%@Import NameSpace="System.IO"%>
<%@Import NameSpace="System"%>
<%@Import NameSpace="Bll"%>
<% @ Page Language="C#" %>
<%


DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
TimeSpan toNow = dtNow.Subtract(dtStart);
string timeStamp = toNow.Ticks.ToString();
timeStamp = timeStamp.Substring(0,timeStamp.Length - 7);


String savePath = "/UserImg/Img/";
String savePicName = timeStamp;


String file_src = savePath + savePicName + "_src.jpg";
String filename162 = savePath + savePicName  + "_162.jpg";
String filename48 = savePath + savePicName  + "_48.jpg";
String filename20 = savePath + savePicName  + "_20.jpg"; 


String pic = Request.Form["pic"];
String pic1 = Request.Form["pic1"];
String pic2 = Request.Form["pic2"];
String pic3 = Request.Form["pic3"];

//原图
if (pic.Length == 0) {
}else {
	byte[] bytes = Convert.FromBase64String(pic);  //将2进制编码转换为8位无符号整数数组
	
	FileStream fs =new FileStream(Server.MapPath(file_src),System.IO.FileMode.Create);
	fs.Write(bytes, 0, bytes.Length);
	fs.Close();
}

byte[] bytes1 = Convert.FromBase64String(pic1);  //将2进制编码转换为8位无符号整数数组.
byte[] bytes2 = Convert.FromBase64String(pic2);  //将2进制编码转换为8位无符号整数数组.
byte[] bytes3 = Convert.FromBase64String(pic3);  //将2进制编码转换为8位无符号整数数组.



//图1
FileStream fs1 =new FileStream(Server.MapPath(filename162),System.IO.FileMode.Create);
fs1.Write(bytes1, 0, bytes1.Length);
fs1.Close();

//图2
FileStream fs2 =new FileStream(Server.MapPath(filename48),System.IO.FileMode.Create);
fs2.Write(bytes2, 0, bytes2.Length);
fs2.Close();

//图3
FileStream fs3 =new FileStream(Server.MapPath(filename20),System.IO.FileMode.Create);
fs3.Write(bytes3, 0, bytes3.Length);
fs3.Close();
string userid=Request["id"];
string picUrl = savePath + savePicName;
CMSService.UpdateFieldOneByOne("User", "CMSUser", "UserId=" + userid, "UserImg", picUrl);
Response.Write("{\"status\":1,");
Response.Write("\"picUrl\":\""+picUrl+"\"}");



%> 