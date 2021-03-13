using System;
using System.IO;
using System.Windows.Forms;

namespace SVN_Updater {
public partial class MainWindow : Form
{
    static string currentDir = Environment.CurrentDirectory;
    static string setting = currentDir + "\\setting.ini";
    static string selected = currentDir + "\\selecteditems.txt";
    static string svnfolder = "";
    static bool svnfoldervalid = false;
    int selfolc = 0;
    int selfoli = 0;
    static string selfol = "";
    string[] fols = new string[20];
    public MainWindow()
    {
        Initialize();
        InitializeComponent();
        CheckPath();
        ListFolders();
        SVNFolderTextBox.Text = svnfolder;
    }

    void Initialize()
    {
        if ( File.Exists( setting ) )
        {
            StreamReader sets = new StreamReader( setting );
            int lineNumber = 0;
            string line = sets.ReadLine();
            while ( line != null )
            {
                lineNumber++;
                line = sets.ReadLine();
                if ( lineNumber == 1 ) { svnfolder = line; }
            }
            sets.Close();
        }
        else
        {
            using ( FileStream fileS = new FileStream( setting, FileMode.Create ) ) { Set(); }
        }

        if ( File.Exists( selected ) )
        { Remove(); }
        else
        {
            using ( FileStream fileF = new FileStream( selected, FileMode.Create ) ) { }
        }
    }

    static void Set()
    {
        StreamWriter settings = new StreamWriter( "setting.ini" );
        settings.WriteLine( "*** SVN Updater settings ***" );
        settings.WriteLine( svnfolder );
        settings.Close();
    }

    void CheckPath()
    {
        if ( Directory.Exists( svnfolder ) ) { svnfoldervalid = true; }
        else { svnfoldervalid = false; }
        StatusValid();
    }

    void StatusValid()
    {
        if ( svnfoldervalid )
        {
            UpdateButton.Enabled = true;
        }
        else
        {
            UpdateButton.Enabled = false;
        }
    }

    void ListFolders()
    {
        FoldersListBox.Items.Clear();
        if ( svnfoldervalid )
        {
            string[] dirs = Directory.GetDirectories( svnfolder );
            foreach ( string dir in dirs )
            {
                if ( Directory.Exists( dir + "\\.svn" ) )
                {
                    FoldersListBox.Items.Add( Path.GetFileName( dir ) );
                }
            }
        }
    }

    void Remove()
    {
        if ( File.Exists( selected ) )
        { File.Delete( selected ); }
    }

    void AddSelFol()
    {        
        StreamWriter addfolder = new StreamWriter( selected );
        for (int i = 0; i < 20; i++)
        {
            addfolder.Write(i + " ");
            addfolder.WriteLine(fols[i]);
        }
        addfolder.Close();
    }

    private void BrowseButton_Click( object sender, EventArgs e )
    {
        FolderBrowserDialog SVNFolder = new FolderBrowserDialog();
        SVNFolder.SelectedPath = svnfolder;
        SVNFolder.Description = "Choose a folder where are stored SVN repositories";
        if ( SVNFolder.ShowDialog() == DialogResult.OK )
        {
            SVNFolderTextBox.Text = SVNFolder.SelectedPath;
            svnfolder = SVNFolder.SelectedPath;
            Set();
        }
    }

    public void UpdateButton_Click( object sender, EventArgs e )
    {
        MessageBox.Show( selfolc.ToString() );
    }

    private void SVNFolderTextBox_TextChanged( object sender, EventArgs e )
    {
        svnfolder = SVNFolderTextBox.Text;
        Set();
        CheckPath();
        ListFolders();
    }

    private void FoldersListBox_SelectedIndexChanged( object sender, EventArgs e )
    {
        if ( FoldersListBox.SelectedItems.Count != 0 )
        { selfol = FoldersListBox.SelectedItem.ToString(); }
        else { selfol = ""; }
        selfolc = FoldersListBox.SelectedItems.Count;
        selfoli = FoldersListBox.SelectedIndex;
        fols[selfoli] = selfol;
        AddSelFol();
    }

    private void MainWindow_FormClosing( object sender, FormClosingEventArgs e )
    {
        Remove();
    }
}
}
