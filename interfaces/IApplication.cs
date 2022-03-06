namespace Calculator
{
    public interface IApplication
    {
        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        public event EventHandler<MouseClickedEventArgs> MouseClicked;
        public event EventHandler<RenderEventArgs> Render;
        public void Logic(ComponentID sender);
    }
}