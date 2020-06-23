namespace BilibiliDown
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.转mp3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkVideoSavePath = new System.Windows.Forms.LinkLabel();
            this.linkSoftSavePath = new System.Windows.Forms.LinkLabel();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GlobalConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCert = new System.Windows.Forms.ToolStripMenuItem();
            this.登录B站账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常见问题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPhoneBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.要你帅3000工具箱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pageVideoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataGridViewProgressColumn1 = new BilibiliDown.Controls.DataGridViewProgressColumn();
            this.mnuRedown = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lsbAnalysisResult = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowImg = new System.Windows.Forms.Button();
            this.btnClearUrl = new System.Windows.Forms.Button();
            this.labError = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.labAnalysis = new System.Windows.Forms.Label();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.labUrlTxt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDowntable = new System.Windows.Forms.DataGridView();
            this.ContextMenuForVideoList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRemoveOne = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.downTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSize = new BilibiliDown.Controls.DataGridViewProgressColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageVideoBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDowntable)).BeginInit();
            this.ContextMenuForVideoList.SuspendLayout();
            this.SuspendLayout();
            // 
            // 转mp3ToolStripMenuItem
            // 
            this.转mp3ToolStripMenuItem.Name = "转mp3ToolStripMenuItem";
            this.转mp3ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.转mp3ToolStripMenuItem.Text = "转mp3";
            this.转mp3ToolStripMenuItem.Click += new System.EventHandler(this.转mp3ToolStripMenuItem_Click);
            // 
            // linkVideoSavePath
            // 
            this.linkVideoSavePath.AutoSize = true;
            this.linkVideoSavePath.Location = new System.Drawing.Point(107, 381);
            this.linkVideoSavePath.Name = "linkVideoSavePath";
            this.linkVideoSavePath.Size = new System.Drawing.Size(0, 12);
            this.linkVideoSavePath.TabIndex = 15;
            this.linkVideoSavePath.Click += new System.EventHandler(this.linkVideoSavePath_Click);
            // 
            // linkSoftSavePath
            // 
            this.linkSoftSavePath.AutoSize = true;
            this.linkSoftSavePath.Location = new System.Drawing.Point(107, 356);
            this.linkSoftSavePath.Name = "linkSoftSavePath";
            this.linkSoftSavePath.Size = new System.Drawing.Size(0, 12);
            this.linkSoftSavePath.TabIndex = 16;
            this.linkSoftSavePath.Click += new System.EventHandler(this.linkSoftSavePath_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 381);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 12);
            this.label22.TabIndex = 13;
            this.label22.Text = "视频保存目录: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "软件保存目录: ";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GlobalConfigToolStripMenuItem,
            this.toolStripCert});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "系统配置";
            // 
            // GlobalConfigToolStripMenuItem
            // 
            this.GlobalConfigToolStripMenuItem.Name = "GlobalConfigToolStripMenuItem";
            this.GlobalConfigToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GlobalConfigToolStripMenuItem.Text = "设置保存路径";
            this.GlobalConfigToolStripMenuItem.Click += new System.EventHandler(this.GlobalConfigToolStripMenuItem_Click);
            // 
            // toolStripCert
            // 
            this.toolStripCert.Name = "toolStripCert";
            this.toolStripCert.Size = new System.Drawing.Size(148, 22);
            this.toolStripCert.Text = "手工保存证书";
            this.toolStripCert.Click += new System.EventHandler(this.toolStripCert_Click);
            // 
            // 登录B站账号ToolStripMenuItem
            // 
            this.登录B站账号ToolStripMenuItem.Name = "登录B站账号ToolStripMenuItem";
            this.登录B站账号ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.登录B站账号ToolStripMenuItem.Text = "登录B站账号";
            this.登录B站账号ToolStripMenuItem.Click += new System.EventHandler(this.登录B站账号ToolStripMenuItem_Click);
            // 
            // 常见问题ToolStripMenuItem
            // 
            this.常见问题ToolStripMenuItem.Name = "常见问题ToolStripMenuItem";
            this.常见问题ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.常见问题ToolStripMenuItem.Text = "常见问题";
            this.常见问题ToolStripMenuItem.Click += new System.EventHandler(this.常见问题ToolStripMenuItem_Click);
            // 
            // toolStripPhoneBarcode
            // 
            this.toolStripPhoneBarcode.Name = "toolStripPhoneBarcode";
            this.toolStripPhoneBarcode.Size = new System.Drawing.Size(140, 21);
            this.toolStripPhoneBarcode.Text = "安卓手机链接下载目录";
            this.toolStripPhoneBarcode.Visible = false;
            this.toolStripPhoneBarcode.Click += new System.EventHandler(this.toolStripPhoneBarcode_Click);
            // 
            // 要你帅3000工具箱ToolStripMenuItem
            // 
            this.要你帅3000工具箱ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.要你帅3000工具箱ToolStripMenuItem.Name = "要你帅3000工具箱ToolStripMenuItem";
            this.要你帅3000工具箱ToolStripMenuItem.Size = new System.Drawing.Size(120, 21);
            this.要你帅3000工具箱ToolStripMenuItem.Text = "要你帅3000工具箱";
            this.要你帅3000工具箱ToolStripMenuItem.Click += new System.EventHandler(this.要你帅3000工具箱ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusVersion,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(801, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(340, 17);
            this.toolStripStatusLabel5.Text = "本软件只为学习和研究软件技术之用。不得商用。也不会收费  ";
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel6.Text = "|";
            // 
            // toolStripStatusVersion
            // 
            this.toolStripStatusVersion.Name = "toolStripStatusVersion";
            this.toolStripStatusVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusVersion.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusVersion.Text = "版本号";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "进群讨论";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click_1);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(239, 17);
            this.toolStripStatusLabel4.Text = "小贴士:双击列表中的视频可以打开视频目录";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.登录B站账号ToolStripMenuItem,
            this.常见问题ToolStripMenuItem,
            this.toolStripPhoneBarcode,
            this.要你帅3000工具箱ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.DataPropertyName = "processbar";
            this.dataGridViewProgressColumn1.HeaderText = "进度";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            // 
            // mnuRedown
            // 
            this.mnuRedown.Name = "mnuRedown";
            this.mnuRedown.Size = new System.Drawing.Size(148, 22);
            this.mnuRedown.Text = "重新下载";
            this.mnuRedown.Click += new System.EventHandler(this.mnuRedown_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(80, 2);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(267, 21);
            this.txtUrl.TabIndex = 0;
            // 
            // lsbAnalysisResult
            // 
            this.lsbAnalysisResult.DisplayMember = "音视频解析结果";
            this.lsbAnalysisResult.FormattingEnabled = true;
            this.lsbAnalysisResult.ItemHeight = 12;
            this.lsbAnalysisResult.Location = new System.Drawing.Point(5, 87);
            this.lsbAnalysisResult.Name = "lsbAnalysisResult";
            this.lsbAnalysisResult.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbAnalysisResult.Size = new System.Drawing.Size(342, 196);
            this.lsbAnalysisResult.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowImg);
            this.panel1.Controls.Add(this.btnClearUrl);
            this.panel1.Controls.Add(this.labError);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.labAnalysis);
            this.panel1.Controls.Add(this.btnAnalysis);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.labUrlTxt);
            this.panel1.Controls.Add(this.lsbAnalysisResult);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 318);
            this.panel1.TabIndex = 9;
            // 
            // btnShowImg
            // 
            this.btnShowImg.Location = new System.Drawing.Point(275, 29);
            this.btnShowImg.Name = "btnShowImg";
            this.btnShowImg.Size = new System.Drawing.Size(72, 23);
            this.btnShowImg.TabIndex = 6;
            this.btnShowImg.Text = "视频图片";
            this.btnShowImg.UseVisualStyleBackColor = true;
            this.btnShowImg.Click += new System.EventHandler(this.btnShowImg_Click);
            // 
            // btnClearUrl
            // 
            this.btnClearUrl.Location = new System.Drawing.Point(207, 29);
            this.btnClearUrl.Name = "btnClearUrl";
            this.btnClearUrl.Size = new System.Drawing.Size(62, 23);
            this.btnClearUrl.TabIndex = 6;
            this.btnClearUrl.Text = "清除网址";
            this.btnClearUrl.UseVisualStyleBackColor = true;
            this.btnClearUrl.Click += new System.EventHandler(this.btnClearUrl_Click);
            // 
            // labError
            // 
            this.labError.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labError.ForeColor = System.Drawing.Color.Red;
            this.labError.Location = new System.Drawing.Point(95, 63);
            this.labError.Name = "labError";
            this.labError.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labError.Size = new System.Drawing.Size(252, 21);
            this.labError.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(5, 293);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(342, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "②开始下载";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // labAnalysis
            // 
            this.labAnalysis.AutoSize = true;
            this.labAnalysis.Location = new System.Drawing.Point(0, 63);
            this.labAnalysis.Name = "labAnalysis";
            this.labAnalysis.Size = new System.Drawing.Size(89, 12);
            this.labAnalysis.TabIndex = 4;
            this.labAnalysis.Text = "音视频解析结果";
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(5, 29);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(196, 23);
            this.btnAnalysis.TabIndex = 3;
            this.btnAnalysis.Text = "①解析地址";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // labUrlTxt
            // 
            this.labUrlTxt.AutoSize = true;
            this.labUrlTxt.Location = new System.Drawing.Point(3, 5);
            this.labUrlTxt.Name = "labUrlTxt";
            this.labUrlTxt.Size = new System.Drawing.Size(71, 12);
            this.labUrlTxt.TabIndex = 1;
            this.labUrlTxt.Text = "音视频地址:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDowntable);
            this.panel2.Location = new System.Drawing.Point(369, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 316);
            this.panel2.TabIndex = 10;
            // 
            // gridDowntable
            // 
            this.gridDowntable.AllowUserToAddRows = false;
            this.gridDowntable.AllowUserToDeleteRows = false;
            this.gridDowntable.AutoGenerateColumns = false;
            this.gridDowntable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDowntable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.downTypeDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.aidDataGridViewTextBoxColumn,
            this.pDataGridViewTextBoxColumn,
            this.cidDataGridViewTextBoxColumn,
            this.midDataGridViewTextBoxColumn,
            this.pageIndexDataGridViewTextBoxColumn,
            this.totalSize});
            this.gridDowntable.ContextMenuStrip = this.ContextMenuForVideoList;
            this.gridDowntable.DataSource = this.pageVideoBindingSource;
            this.gridDowntable.Location = new System.Drawing.Point(4, 2);
            this.gridDowntable.Name = "gridDowntable";
            this.gridDowntable.ReadOnly = true;
            this.gridDowntable.RowTemplate.Height = 23;
            this.gridDowntable.Size = new System.Drawing.Size(427, 316);
            this.gridDowntable.TabIndex = 0;
            this.gridDowntable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.gridDowntable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.gridDowntable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDowntable_CellMouseDown);
            this.gridDowntable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            // 
            // ContextMenuForVideoList
            // 
            this.ContextMenuForVideoList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoveOne,
            this.mnuClearAll,
            this.mnuRedown,
            this.转mp3ToolStripMenuItem});
            this.ContextMenuForVideoList.Name = "ContextMenuForVideoList";
            this.ContextMenuForVideoList.Size = new System.Drawing.Size(149, 92);
            // 
            // mnuRemoveOne
            // 
            this.mnuRemoveOne.Name = "mnuRemoveOne";
            this.mnuRemoveOne.Size = new System.Drawing.Size(148, 22);
            this.mnuRemoveOne.Text = "删除该条记录";
            this.mnuRemoveOne.Click += new System.EventHandler(this.mnuRemoveOne_Click);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(148, 22);
            this.mnuClearAll.Text = "清空列表";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "SavePath";
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "码";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // downTypeDataGridViewTextBoxColumn
            // 
            this.downTypeDataGridViewTextBoxColumn.DataPropertyName = "DownType";
            this.downTypeDataGridViewTextBoxColumn.HeaderText = "状态";
            this.downTypeDataGridViewTextBoxColumn.Name = "downTypeDataGridViewTextBoxColumn";
            this.downTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "名称";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aidDataGridViewTextBoxColumn
            // 
            this.aidDataGridViewTextBoxColumn.DataPropertyName = "aid";
            this.aidDataGridViewTextBoxColumn.HeaderText = "aid";
            this.aidDataGridViewTextBoxColumn.Name = "aidDataGridViewTextBoxColumn";
            this.aidDataGridViewTextBoxColumn.ReadOnly = true;
            this.aidDataGridViewTextBoxColumn.Visible = false;
            // 
            // pDataGridViewTextBoxColumn
            // 
            this.pDataGridViewTextBoxColumn.DataPropertyName = "p";
            this.pDataGridViewTextBoxColumn.HeaderText = "p";
            this.pDataGridViewTextBoxColumn.Name = "pDataGridViewTextBoxColumn";
            this.pDataGridViewTextBoxColumn.ReadOnly = true;
            this.pDataGridViewTextBoxColumn.Visible = false;
            // 
            // cidDataGridViewTextBoxColumn
            // 
            this.cidDataGridViewTextBoxColumn.DataPropertyName = "cid";
            this.cidDataGridViewTextBoxColumn.HeaderText = "cid";
            this.cidDataGridViewTextBoxColumn.Name = "cidDataGridViewTextBoxColumn";
            this.cidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cidDataGridViewTextBoxColumn.Visible = false;
            // 
            // midDataGridViewTextBoxColumn
            // 
            this.midDataGridViewTextBoxColumn.DataPropertyName = "mid";
            this.midDataGridViewTextBoxColumn.HeaderText = "mid";
            this.midDataGridViewTextBoxColumn.Name = "midDataGridViewTextBoxColumn";
            this.midDataGridViewTextBoxColumn.ReadOnly = true;
            this.midDataGridViewTextBoxColumn.Visible = false;
            // 
            // pageIndexDataGridViewTextBoxColumn
            // 
            this.pageIndexDataGridViewTextBoxColumn.DataPropertyName = "pageIndex";
            this.pageIndexDataGridViewTextBoxColumn.HeaderText = "pageIndex";
            this.pageIndexDataGridViewTextBoxColumn.Name = "pageIndexDataGridViewTextBoxColumn";
            this.pageIndexDataGridViewTextBoxColumn.ReadOnly = true;
            this.pageIndexDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalSize
            // 
            this.totalSize.DataPropertyName = "processbar";
            this.totalSize.HeaderText = "进度";
            this.totalSize.Name = "totalSize";
            this.totalSize.ReadOnly = true;
            this.totalSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 436);
            this.Controls.Add(this.linkVideoSavePath);
            this.Controls.Add(this.linkSoftSavePath);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载工具-三叔";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageVideoBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDowntable)).EndInit();
            this.ContextMenuForVideoList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 转mp3ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkVideoSavePath;
        private System.Windows.Forms.LinkLabel linkSoftSavePath;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem GlobalConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripCert;
        private System.Windows.Forms.ToolStripMenuItem 登录B站账号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 常见问题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripPhoneBarcode;
        private System.Windows.Forms.ToolStripMenuItem 要你帅3000工具箱ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.BindingSource pageVideoBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private Controls.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.ToolStripMenuItem mnuRedown;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ListBox lsbAnalysisResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowImg;
        private System.Windows.Forms.Button btnClearUrl;
        private System.Windows.Forms.Label labError;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label labAnalysis;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Label labUrlTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridDowntable;
        private System.Windows.Forms.ContextMenuStrip ContextMenuForVideoList;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveOne;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn downTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn midDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pageIndexDataGridViewTextBoxColumn;
        private Controls.DataGridViewProgressColumn totalSize;
    }
}

