/*
 * 由SharpDevelop创建。
 * 用户： zhulin
 * 日期: 15/1/21 星期三
 * 时间: 11:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace EnvTool
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView lvSysEnv;
		private System.Windows.Forms.ColumnHeader colhSysVar;
		private System.Windows.Forms.ColumnHeader colhSysVal;
		private System.Windows.Forms.TabControl tbcCont;
		private System.Windows.Forms.TabPage tabpSys;
		private System.Windows.Forms.TabPage tabpUser;
		private System.Windows.Forms.ListView lvUserEnv;
		private System.Windows.Forms.ColumnHeader colhUserVar;
		private System.Windows.Forms.ColumnHeader colhUserVal;
		private System.Windows.Forms.SplitContainer splcCont;
		private System.Windows.Forms.TextBox txbVal;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txbVarName;
		private System.Windows.Forms.FlowLayoutPanel flpFunc;
		private System.Windows.Forms.TabPage tabpAbout;
		private System.Windows.Forms.Label labAuthor;
		private System.Windows.Forms.LinkLabel lnkbHomePage;
		private System.Windows.Forms.Label labName;
		private System.Windows.Forms.Label lblHomePageText;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// </summary>
		protected void InitializeComponent()
		{
			this.tbcCont = new System.Windows.Forms.TabControl();
			this.tabpSys = new System.Windows.Forms.TabPage();
			this.lvSysEnv = new System.Windows.Forms.ListView();
			this.colhSysVar = new System.Windows.Forms.ColumnHeader();
			this.colhSysVal = new System.Windows.Forms.ColumnHeader();
			this.tabpUser = new System.Windows.Forms.TabPage();
			this.lvUserEnv = new System.Windows.Forms.ListView();
			this.colhUserVar = new System.Windows.Forms.ColumnHeader();
			this.colhUserVal = new System.Windows.Forms.ColumnHeader();
			this.tabpAbout = new System.Windows.Forms.TabPage();
			this.lblHomePageText = new System.Windows.Forms.Label();
			this.labAuthor = new System.Windows.Forms.Label();
			this.lnkbHomePage = new System.Windows.Forms.LinkLabel();
			this.labName = new System.Windows.Forms.Label();
			this.splcCont = new System.Windows.Forms.SplitContainer();
			this.flpFunc = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.txbVal = new System.Windows.Forms.TextBox();
			this.txbVarName = new System.Windows.Forms.TextBox();
			this.tbcCont.SuspendLayout();
			this.tabpSys.SuspendLayout();
			this.tabpUser.SuspendLayout();
			this.tabpAbout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splcCont)).BeginInit();
			this.splcCont.Panel1.SuspendLayout();
			this.splcCont.Panel2.SuspendLayout();
			this.splcCont.SuspendLayout();
			this.flpFunc.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcCont
			// 
			this.tbcCont.Controls.Add(this.tabpSys);
			this.tbcCont.Controls.Add(this.tabpUser);
			this.tbcCont.Controls.Add(this.tabpAbout);
			this.tbcCont.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcCont.Location = new System.Drawing.Point(0, 0);
			this.tbcCont.Name = "tbcCont";
			this.tbcCont.SelectedIndex = 0;
			this.tbcCont.Size = new System.Drawing.Size(797, 283);
			this.tbcCont.TabIndex = 2;
			// 
			// tabpSys
			// 
			this.tabpSys.Controls.Add(this.lvSysEnv);
			this.tabpSys.Location = new System.Drawing.Point(4, 22);
			this.tabpSys.Name = "tabpSys";
			this.tabpSys.Padding = new System.Windows.Forms.Padding(3);
			this.tabpSys.Size = new System.Drawing.Size(789, 257);
			this.tabpSys.TabIndex = 0;
			this.tabpSys.Text = "系统";
			this.tabpSys.UseVisualStyleBackColor = true;
			// 
			// lvSysEnv
			// 
			this.lvSysEnv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.colhSysVar,
			this.colhSysVal});
			this.lvSysEnv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSysEnv.FullRowSelect = true;
			this.lvSysEnv.Location = new System.Drawing.Point(3, 3);
			this.lvSysEnv.Name = "lvSysEnv";
			this.lvSysEnv.Size = new System.Drawing.Size(783, 251);
			this.lvSysEnv.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSysEnv.TabIndex = 0;
			this.lvSysEnv.UseCompatibleStateImageBehavior = false;
			this.lvSysEnv.View = System.Windows.Forms.View.Details;
			this.lvSysEnv.SelectedIndexChanged += new System.EventHandler(this.LvSysEnvSelectedIndexChanged);
			// 
			// colhSysVar
			// 
			this.colhSysVar.Text = "变量";
			this.colhSysVar.Width = 160;
			// 
			// colhSysVal
			// 
			this.colhSysVal.Text = "值";
			this.colhSysVal.Width = 600;
			// 
			// tabpUser
			// 
			this.tabpUser.Controls.Add(this.lvUserEnv);
			this.tabpUser.Location = new System.Drawing.Point(4, 22);
			this.tabpUser.Name = "tabpUser";
			this.tabpUser.Padding = new System.Windows.Forms.Padding(3);
			this.tabpUser.Size = new System.Drawing.Size(789, 257);
			this.tabpUser.TabIndex = 1;
			this.tabpUser.Text = "用户";
			this.tabpUser.UseVisualStyleBackColor = true;
			// 
			// lvUserEnv
			// 
			this.lvUserEnv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.colhUserVar,
			this.colhUserVal});
			this.lvUserEnv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvUserEnv.FullRowSelect = true;
			this.lvUserEnv.Location = new System.Drawing.Point(3, 3);
			this.lvUserEnv.Name = "lvUserEnv";
			this.lvUserEnv.Size = new System.Drawing.Size(783, 251);
			this.lvUserEnv.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvUserEnv.TabIndex = 1;
			this.lvUserEnv.UseCompatibleStateImageBehavior = false;
			this.lvUserEnv.View = System.Windows.Forms.View.Details;
			this.lvUserEnv.SelectedIndexChanged += new System.EventHandler(this.LvUserEnvSelectedIndexChanged);
			// 
			// colhUserVar
			// 
			this.colhUserVar.Text = "变量";
			this.colhUserVar.Width = 160;
			// 
			// colhUserVal
			// 
			this.colhUserVal.Text = "值";
			this.colhUserVal.Width = 260;
			// 
			// tabpAbout
			// 
			this.tabpAbout.Controls.Add(this.lblHomePageText);
			this.tabpAbout.Controls.Add(this.labAuthor);
			this.tabpAbout.Controls.Add(this.lnkbHomePage);
			this.tabpAbout.Controls.Add(this.labName);
			this.tabpAbout.Location = new System.Drawing.Point(4, 22);
			this.tabpAbout.Name = "tabpAbout";
			this.tabpAbout.Padding = new System.Windows.Forms.Padding(3);
			this.tabpAbout.Size = new System.Drawing.Size(789, 257);
			this.tabpAbout.TabIndex = 2;
			this.tabpAbout.Text = "关于";
			this.tabpAbout.UseVisualStyleBackColor = true;
			// 
			// lblHomePageText
			// 
			this.lblHomePageText.Location = new System.Drawing.Point(43, 91);
			this.lblHomePageText.Name = "lblHomePageText";
			this.lblHomePageText.Size = new System.Drawing.Size(43, 23);
			this.lblHomePageText.TabIndex = 3;
			this.lblHomePageText.Text = "官网：";
			// 
			// labAuthor
			// 
			this.labAuthor.Location = new System.Drawing.Point(43, 68);
			this.labAuthor.Name = "labAuthor";
			this.labAuthor.Size = new System.Drawing.Size(100, 23);
			this.labAuthor.TabIndex = 2;
			this.labAuthor.Text = "作者： zhulin";
			// 
			// lnkbHomePage
			// 
			this.lnkbHomePage.Location = new System.Drawing.Point(86, 92);
			this.lnkbHomePage.Name = "lnkbHomePage";
			this.lnkbHomePage.Size = new System.Drawing.Size(248, 23);
			this.lnkbHomePage.TabIndex = 1;
			this.lnkbHomePage.TabStop = true;
			this.lnkbHomePage.Text = "https://github.com/zhulin3141/EnvTool";
			this.lnkbHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkbHomePageLinkClicked);
			// 
			// labName
			// 
			this.labName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.labName.Location = new System.Drawing.Point(43, 25);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(100, 23);
			this.labName.TabIndex = 0;
			this.labName.Text = "EnvTool";
			// 
			// splcCont
			// 
			this.splcCont.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splcCont.Location = new System.Drawing.Point(0, 0);
			this.splcCont.Name = "splcCont";
			this.splcCont.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splcCont.Panel1
			// 
			this.splcCont.Panel1.Controls.Add(this.tbcCont);
			// 
			// splcCont.Panel2
			// 
			this.splcCont.Panel2.Controls.Add(this.flpFunc);
			this.splcCont.Panel2.Controls.Add(this.txbVal);
			this.splcCont.Panel2.Controls.Add(this.txbVarName);
			this.splcCont.Size = new System.Drawing.Size(797, 436);
			this.splcCont.SplitterDistance = 283;
			this.splcCont.TabIndex = 1;
			// 
			// flpFunc
			// 
			this.flpFunc.Controls.Add(this.btnAdd);
			this.flpFunc.Controls.Add(this.btnEdit);
			this.flpFunc.Controls.Add(this.btnDel);
			this.flpFunc.Dock = System.Windows.Forms.DockStyle.Top;
			this.flpFunc.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.flpFunc.Location = new System.Drawing.Point(0, 105);
			this.flpFunc.Name = "flpFunc";
			this.flpFunc.Size = new System.Drawing.Size(797, 38);
			this.flpFunc.TabIndex = 2;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(3, 6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(76, 29);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "新增";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEdit.Location = new System.Drawing.Point(85, 6);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(76, 29);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "修改";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDel.Location = new System.Drawing.Point(167, 6);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(76, 29);
			this.btnDel.TabIndex = 1;
			this.btnDel.Text = "删除";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.BtnDelClick);
			// 
			// txbVal
			// 
			this.txbVal.Dock = System.Windows.Forms.DockStyle.Top;
			this.txbVal.Location = new System.Drawing.Point(0, 21);
			this.txbVal.Multiline = true;
			this.txbVal.Name = "txbVal";
			this.txbVal.Size = new System.Drawing.Size(797, 84);
			this.txbVal.TabIndex = 1;
			// 
			// txbVarName
			// 
			this.txbVarName.Dock = System.Windows.Forms.DockStyle.Top;
			this.txbVarName.Location = new System.Drawing.Point(0, 0);
			this.txbVarName.Name = "txbVarName";
			this.txbVarName.Size = new System.Drawing.Size(797, 21);
			this.txbVarName.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(797, 436);
			this.Controls.Add(this.splcCont);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EnvTool";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tbcCont.ResumeLayout(false);
			this.tabpSys.ResumeLayout(false);
			this.tabpUser.ResumeLayout(false);
			this.tabpAbout.ResumeLayout(false);
			this.splcCont.Panel1.ResumeLayout(false);
			this.splcCont.Panel2.ResumeLayout(false);
			this.splcCont.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splcCont)).EndInit();
			this.splcCont.ResumeLayout(false);
			this.flpFunc.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
