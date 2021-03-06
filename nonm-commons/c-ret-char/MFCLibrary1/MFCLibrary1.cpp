// MFCLibrary1.cpp: 定义 DLL 的初始化例程。
//

#include "stdafx.h"
#include "MFCLibrary1.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

//
//TODO:  如果此 DLL 相对于 MFC DLL 是动态链接的，
//		则从此 DLL 导出的任何调入
//		MFC 的函数必须将 AFX_MANAGE_STATE 宏添加到
//		该函数的最前面。
//
//		例如: 
//
//		extern "C" BOOL PASCAL EXPORT ExportedFunction()
//		{
//			AFX_MANAGE_STATE(AfxGetStaticModuleState());
//			// 此处为普通函数体
//		}
//
//		此宏先于任何 MFC 调用
//		出现在每个函数中十分重要。  这意味着
//		它必须作为以下项中的第一个语句:
//		出现，甚至先于所有对象变量声明，
//		这是因为它们的构造函数可能生成 MFC
//		DLL 调用。
//
//		有关其他详细信息，
//		请参阅 MFC 技术说明 33 和 58。
//

// CMFCLibrary1App

BEGIN_MESSAGE_MAP(CMFCLibrary1App, CWinApp)
END_MESSAGE_MAP()


// CMFCLibrary1App 构造

CMFCLibrary1App::CMFCLibrary1App()
{
	// TODO:  在此处添加构造代码，
	// 将所有重要的初始化放置在 InitInstance 中
}


// 唯一的 CMFCLibrary1App 对象

CMFCLibrary1App theApp;


// CMFCLibrary1App 初始化

BOOL CMFCLibrary1App::InitInstance()
{
	CWinApp::InitInstance();

	return TRUE;
}

char * ReturnText()
{
	CString info;
	info.Format(_T("{\"uid\": %u, \"nick\": \"%s\"}"), 10001, CStringW("王经理"));

	/*
		参考文章
		https://blog.csdn.net/u010306834/article/details/39495305
		https://www.cnblogs.com/junyuz/archive/2011/08/24/2151857.html
	*/
	//注意：以下n和len的值大小不同,n是按字符计算的，len是按字节计算的
	int n = info.GetLength();     // n = 14, len = 18
	//获取宽字节字符的大小，大小是按字节计算的
	int len = WideCharToMultiByte(CP_ACP, 0, info, info.GetLength(), NULL, 0, NULL, NULL);
	//为多字节字符数组申请空间，数组大小为按字节计算的宽字节字节大小
	char * pChar = new char[len + 1];   //以字节为单位
	//宽字节编码转换成多字节编码
	WideCharToMultiByte(CP_ACP, 0, info, info.GetLength() + 1, pChar, len + 1, NULL, NULL);
	pChar[len] = '\0';   //多字节字符以'\0'结束

	return pChar;
}

