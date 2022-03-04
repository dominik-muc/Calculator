namespace Calculator
{
    public class MouseClickedEventArgs : EventArgs
    {
        public readonly Point mousePosition;
        public MouseClickedEventArgs(Point mousePosition)
        {
            this.mousePosition = mousePosition;
        }
    }
}