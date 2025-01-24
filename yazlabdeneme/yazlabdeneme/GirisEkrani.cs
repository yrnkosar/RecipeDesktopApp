using LibVLCSharp.Shared;

namespace yazlabdeneme
{
    public partial class GirisEkrani : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        public GirisEkrani()
        {
            InitializeComponent();
            Core.Initialize(); 

        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        { 
            _mediaPlayer?.Stop();

            
            AnaMenuForm anaMenu = new AnaMenuForm();
            anaMenu.Show();
            this.Hide(); 
        }

        private void btnStokKontrol_Click(object sender, EventArgs e)
        {  
            _mediaPlayer?.Stop();
            
            StokKontrolForm stokKontrol = new StokKontrolForm();
            stokKontrol.Show();
            this.Hide(); 
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

           
            var videoView = new LibVLCSharp.WinForms.VideoView
            {
                Dock = DockStyle.Fill
            };

           
            panel1.Controls.Add(videoView);
            videoView.MediaPlayer = _mediaPlayer;

           
            var videoPath = @"C:\Users\yaren\Desktop\projeResimleri\basvideo.mp4";
            var media = new Media(_libVLC, new Uri(videoPath));

            _mediaPlayer.Play(media);

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _mediaPlayer?.Dispose();
            _libVLC?.Dispose();
            base.OnFormClosing(e);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
