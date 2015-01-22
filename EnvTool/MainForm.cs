/*
 * 由SharpDevelop创建。
 * 用户： zhulin
 * 日期: 15/1/21 星期三
 * 时间: 11:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EnvTool
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		bool existFlag;
		
		//当前面板的ListView
		ListView currListView;
		
		//当前选中的ListViewItem
		ListViewItem currListViewItem;
		
		//当前面板对应的环境变量类型
		EnvironmentVariableTarget envVarTarget;

		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.existFlag = false;
			this.currListView = null;
			this.envVarTarget = EnvironmentVariableTarget.User;
			this.currListViewItem = null;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			this.refreshCurrState();
			
			//设置环境变量列表
			this.bindListViewData(EnvironmentVariableTarget.Machine);
			this.bindListViewData(EnvironmentVariableTarget.User);
	    	
	    	this.setAutoComplete();
	    	this.refreshStateStrip();
		}
		void LvSysEnvSelectedIndexChanged(object sender, EventArgs e)
		{
			flpFunc.Controls.RemoveByKey("ext");
			if( lvSysEnv.SelectedItems.Count == 0 ){				
				this.emptyTextValue();
			}else{
				this.setTextValue();
				this.addExtButton();				
			}			
			
		}
		void LvUserEnvSelectedIndexChanged(object sender, EventArgs e)
		{
			flpFunc.Controls.RemoveByKey("ext");
			if( lvUserEnv.SelectedItems.Count == 0 ){
				this.emptyTextValue();
			}else{
				this.setTextValue();
				this.addExtButton();
			}
			
		}
		void BtnDelClick(object sender, EventArgs e)
		{
			this.refreshCurrState();
			
			if( txbVarName.Text.Trim() == "" ){
				return ;
			}
			
			Environment.SetEnvironmentVariable(txbVarName.Text, null, this.envVarTarget);
			
			if(this.currListView.SelectedItems.Count > 0 ){
				this.currListView.SelectedItems[0].Remove();
				this.emptyTextValue();
			}
			
			this.refreshStateStrip();
		}
		void BtnEditClick(object sender, EventArgs e)
		{
			this.refreshCurrState();
			
			if( txbVarName.Text.Trim() == "" ){
				return ;
			}
			
			Environment.SetEnvironmentVariable(txbVarName.Text, txbVal.Text, this.envVarTarget);
			
			if( this.existFlag ){
				//更新ListView中对应的环境变量的值
				this.currListViewItem.SubItems[1].Text = txbVal.Text;
			}
		}
		void BtnAddClick(object sender, EventArgs e)
		{
			this.refreshCurrState();
			
			if( txbVarName.Text.Trim() == "" && txbVal.Text.Trim() == "" ){
				return;
			}
			
			Environment.SetEnvironmentVariable(txbVarName.Text, txbVal.Text, this.envVarTarget);
			
			if( this.existFlag ){
				this.currListViewItem.SubItems[1].Text = txbVal.Text;
			}else{
				ListViewItem lvi = new ListViewItem();
				
				lvi.Text = lvi.Name = txbVarName.Text;
				lvi.SubItems.Add(txbVal.Text);
				this.currListView.Items.Add(lvi);
			}
			
			this.emptyTextValue();
			this.refreshStateStrip();
		}
		
		/// <summary>
		/// 绑定列表中的数据
		/// </summary>
		/// <param name="target">环境变量的类型</param>
		void bindListViewData(EnvironmentVariableTarget target){
			foreach (DictionaryEntry entity in Environment.GetEnvironmentVariables(target)){
			     ListViewItem lvi = new ListViewItem();
			     
	    		 lvi.Text = lvi.Name = (string)entity.Key;
	    		 lvi.SubItems.Add((string)entity.Value);
	    		 
	    		 if( target == EnvironmentVariableTarget.Machine){
	    		 	lvSysEnv.Items.Add(lvi);
	    		 }else{
	    		 	lvUserEnv.Items.Add(lvi);
	    		 }
			}
		}
		
		void refreshCurrState(){
			//当前是在系统变量面板
			if( tbcCont.SelectedTab == tabpSys ){
				this.currListView = lvSysEnv;
				this.envVarTarget = EnvironmentVariableTarget.Machine;
			}else{
				this.currListView = lvUserEnv;
				this.envVarTarget = EnvironmentVariableTarget.User;
			}
			
			this.existFlag = currListView.Items.ContainsKey(txbVarName.Text);
			if ( this.currListView.SelectedIndices != null && this.currListView.SelectedIndices.Count > 0  ){
				this.currListViewItem = this.currListView.Items[this.currListView.SelectedIndices[0]];
			}
		}
		
		/// <summary>
		/// 设置文本框的值
		/// </summary>
		void setTextValue(){
			this.refreshCurrState();
			
			//激活时在文本框上设置为当前项的值
			if ( this.currListView.SelectedIndices != null && this.currListView.SelectedIndices.Count > 0 )
			{
				txbVarName.Text = this.currListViewItem.SubItems[0].Text;
				txbVal.Text = this.currListViewItem.SubItems[1].Text;
			}
		}
		
		/// <summary>
		/// 清空文本框
		/// </summary>
		void emptyTextValue(){
			txbVarName.Text = "";
			txbVal.Text = "";
		}
		
		/// <summary>
		/// 增强的功能
		/// </summary>
		void addExtButton(){
			Button extButton = new Button();
			extButton.Text = "打开";
			extButton.Name = "ext";
			extButton.Size = btnAdd.Size;
			
			if( this.getCurrEnvVarValue().EndsWith(".exe") ){
				extButton.Click += new EventHandler(openExe);
			}else if( Directory.Exists(this.getCurrEnvVarValue()) ){
				extButton.Click += new EventHandler(openDir);
			}else{
				return ;
			}
			
			flpFunc.Controls.Add(extButton);
		}
		
		void openExe(object sender, EventArgs e){
			Process pr = new Process();
			pr.StartInfo.FileName = "cmd.exe";
			
			if( this.getCurrEnvVarValue().EndsWith("cmd.exe") ){
				pr.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			}else{
				pr.StartInfo.WorkingDirectory = Path.GetDirectoryName(this.getCurrEnvVarValue());
			}
			pr.Start();
		}
		
		void openDir(object sender, EventArgs e){
			Process pr = new Process();
			pr.StartInfo.FileName = "explorer.exe";
			pr.StartInfo.Arguments = this.getCurrEnvVarValue();
			pr.Start();
		}
		
		/// <summary>
		/// 获取当前选中的环境变量的值
		/// </summary>
		/// <returns></returns>
		string getCurrEnvVarValue(){
			return this.currListViewItem.SubItems[1].Text;
		}
		
		void LnkbHomePageLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.lnkbHomePage.Links[0].LinkData = "https://github.com/zhulin3141/EnvTool";  
		    Process.Start(e.Link.LinkData.ToString());  
		}
		
		void setAutoComplete(){
			AutoCompleteStringCollection acList = new AutoCompleteStringCollection();
			acList.AddRange(new string[]{
			                	"MAVEN_HOME",
			                	"CATALINA_BASE",
			                	"CATALINA_HOME",
			                	"TOMCAT_HOME",
			                	"JRE_HOME",
			                	"CLASSPATH",
			                	"JAVA_HOME",
			                	"ANT_HOME",
			                	"JAVA_OPTS",
			                	
			                	"ORACLE_SID",
			                	"ORACLE_HOME",
			                	"TNS_ADMIN",
			                	"NLS_LANG",
			                	"LANG",
			                	
			                	"android",
			                	"ANDROID_HOME",
			                	"ANDROID_SDK_HOME",
			                	
			                	"PYTHONIOENCODING",
			                	
			                	"GOPATH",
			                	"GOROOT",
			                	
			                	"NODEPATH",
			                	
			                	"QTDIR",
			                	"QMAKESPEC",
			                	"QT_INSTALL_PREFIX",
			                	
			                	"ERL_HOME",
			                	
			                	"NDK_ROOT",
			                	
			                	"MINGW",
			                	"LIBRARY_PATH",
			                });
            txbVarName.AutoCompleteCustomSource = acList;
            txbVarName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbVarName.AutoCompleteMode = AutoCompleteMode.Suggest;
		}
		void TxbVarNameTextChanged(object sender, EventArgs e)
		{
			this.refreshCurrState();
			List<ListViewItem> item;
			
			item = new List<ListViewItem>();
			foreach (DictionaryEntry entity in Environment.GetEnvironmentVariables(this.envVarTarget))
	        {
	    		ListViewItem lvi = new ListViewItem();
	    		
	    		lvi.Text = lvi.Name = (string)entity.Key;
	    		lvi.SubItems.Add((string)entity.Value);
	    		item.Add(lvi);
	        }
			
			var search = txbVarName.Text;
			var searchItem = item.Where(m => m.SubItems[0].ToString().Contains(search)).ToList();
			
			//没有选中
			if( this.currListView.SelectedItems.Count == 0 ){
				this.currListView.Items.Clear();
				
				if( searchItem != null ){
					this.currListView.Items.AddRange(searchItem.ToArray());
				}
			}
		}
		
		void refreshStateStrip(){
			var sysCount = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine).Count;
			var userCount = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User).Count;
			this.tsslEnvCount.Text = String.Format("总共有: 系统{0}个,用户{1}个", sysCount, userCount);
		}
	}
}
