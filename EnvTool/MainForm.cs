﻿/*
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
			//设置环境变量的列表
	    	foreach (DictionaryEntry entity in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
	        {
	    		ListViewItem lvi = new ListViewItem();
	    		
	    		lvi.Text = lvi.Name = (string)entity.Key;
	    		lvi.SubItems.Add((string)entity.Value);
	    		lvSysEnv.Items.Add(lvi);
	        }
	    	
	    	foreach (DictionaryEntry entity in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
	        {
	    		ListViewItem lvi = new ListViewItem();
	    		
	    		lvi.Text = lvi.Name = (string)entity.Key;
	    		lvi.SubItems.Add((string)entity.Value);
	    		lvUserEnv.Items.Add(lvi);
	        }
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
	}
}
