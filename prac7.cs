using Microsoft.DirectX; //OUR CODE 
using Microsoft.DirectX.Direct3D;
namespace WindowsFormsApplication7
{
    public partial class Form4 : Form
    {
        Microsoft.DirectX.Direct3D.Device device;
        public Form4()
        {
            InitializeComponent();
            InitDevice();
        }

        private void InitDevice() //OUR CODE 
        { PresentParameters pp = new PresentParameters(); 
            pp.Windowed = true; pp.SwapEffect = SwapEffect.Discard;
device = new Microsoft.DirectX.Direct3D.Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp); 
            device.Transform.Projection = Matrix.PerspectiveFovLH(3.14f / 4, device.Viewport.Width / device.Viewport.Height, 1f, 1000f); 
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, 20), new Vector3(), new Vector3(0, 1, 0)); 
            device.RenderState.Lighting = false; 
        }
        private void Render() //OUR CODE 
        {
          
            CustomVertex.PositionTextured[] vertexes = new CustomVertex.PositionTextured[6]; //6 here is the number of vectors you've defined
            //traingle1 
            vertexes[0] = new CustomVertex.PositionTextured(new Vector3(0, 2, 1), 0, 0); 
            vertexes[1] = new CustomVertex.PositionTextured(new Vector3(0, -2, 1), 0, 1); 
            vertexes[2] = new CustomVertex.PositionTextured(new Vector3(2, -2, 1), -1, 1);
            //traingle2 
            vertexes[3] = new CustomVertex.PositionTextured(new Vector3(2, -2, 1), 0, 0); 
            vertexes[4] = new CustomVertex.PositionTextured(new Vector3(2, 2, 1), 0, 1); 
            vertexes[5] = new CustomVertex.PositionTextured(new Vector3(0, 2, 1), -1, 1);
            Texture texture = new Texture(device, new Bitmap("D:\\notes\\img1.jpg"), 0, Pool.Managed); 
            device.Clear(ClearFlags.Target, Color.Cyan, 1.0f, 0); 
            device.BeginScene(); 
            device.SetTexture(0, texture); 
            device.VertexFormat = CustomVertex.PositionTextured.Format; 
            device.DrawUserPrimitives(PrimitiveType.TriangleList, vertexes.Length / 3, vertexes); 
            //in the above line(vertexes.Length=6, so 6/3=2) hence, 1 for single triangle & 2 for double triangle device.EndScene(); device.Present(); }
            device.EndScene(); 
            device.Present();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("paint");

            Render(); //OUR CODE 
        }
    }
}
