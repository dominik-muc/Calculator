namespace Calculator
{
    public class RenderEventArgs : EventArgs
    {
        public readonly IntPtr renderer;
        public RenderEventArgs(IntPtr renderer) => this.renderer = renderer;
    }
}