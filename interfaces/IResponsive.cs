namespace Calculator
{
    public interface IResponsive
    {
        public void OnKeyPressed(object? sender, KeyPressedEventArgs e);
        public void OnMouseClicked(object? sender, MouseClickedEventArgs e);
        public SDL2.SDL.SDL_Keycode? activationKey{ get; }
    }
}