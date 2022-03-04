using SDL2;

namespace Calculator
{
    public abstract class Component
    {
        public IntPtr texture;
        public IntPtr renderer;
        public SDL.SDL_Rect srcRect;
        public SDL.SDL_Rect destRect;
    }
}