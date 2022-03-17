using AiForms.Dialogs.Abstractions;

namespace TrackingApp.Controls
{
    public partial class QAToastView : ToastView
    {
        public QAToastView()
        {
            InitializeComponent();
        }

        // define appearing animation
        public override void RunPresentationAnimation() { }

        // define disappearing animation
        public override void RunDismissalAnimation() { }

        // define clean up process.
        public override void Destroy() { }
    }
}