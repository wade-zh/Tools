# C++封装MFC DLL时，返回char*数据，如果数据经过CString.format，那么易语言在接收时不能直接接收

感谢以下作者的文章提供了解决方法：  
[https://blog.csdn.net/u010306834/article/details/39495305](https://blog.csdn.net/u010306834/article/details/39495305 "https://blog.csdn.net/u010306834/article/details/39495305")  
[https://www.cnblogs.com/junyuz/archive/2011/08/24/2151857.html](https://www.cnblogs.com/junyuz/archive/2011/08/24/2151857.html "https://www.cnblogs.com/junyuz/archive/2011/08/24/2151857.html")

我的案例问题共有两个，第一我使用了CString格式化，第二我包含了中文字符在内

所以这个demo就是演示了怎么解决这个问题