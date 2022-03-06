using SDL2;

namespace Calculator
{
    public abstract class Component
    {
        public IApplication parent;
        public IntPtr? texture;
        public IntPtr renderer;
        public SDL.SDL_Rect srcRect;
        public SDL.SDL_Rect destRect;
        public Component(IApplication parent)
        {
            this.parent = parent;
        }
    }
}