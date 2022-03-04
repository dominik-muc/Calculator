using SDL2;
namespace Calculator
{
    public class KeyPressedEventArgs : EventArgs
    {
        public readonly SDL.SDL_Keycode keyID;
        public KeyPressedEventArgs(SDL.SDL_Keycode keyID)
        {
            this.keyID = keyID;
        }
    }
}