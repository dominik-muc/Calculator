using SDL2;

namespace Calculator
{
    public class Button : Component, IVisible, IResponsive
    {
        public void Render(object? sender, RenderEventArgs e)
        {
            SDL.SDL_RenderCopy(renderer, texture, ref srcRect, ref destRect);
        }
        public void OnKeyPressed(object? sender, KeyPressedEventArgs e)
        {
            if(e.keyID == _activationKey)
            {
                parent.Logic(id);
            }
        }
        public void OnMouseClicked(object? sender, MouseClickedEventArgs e)
        {
            if
            (
                (e.mousePosition.x > destRect.x) &&
                (e.mousePosition.x < destRect.x + destRect.w) &&
                (e.mousePosition.y > destRect.y) &&
                (e.mousePosition.y < destRect.y + destRect.h)
            )
            {
                parent.Logic(id);
            }         
        }
        public SDL.SDL_Keycode? activationKey
        {
            get => _activationKey;
        }
        private SDL.SDL_Keycode? _activationKey;
        public Button(IApplication parent, ComponentID id, SDL.SDL_Keycode? activationKey, IntPtr texture, IntPtr renderer, SDL.SDL_Rect srcRect, SDL.SDL_Rect destRect) : base(parent)
        {
            _activationKey = activationKey;
            this.id = id;
            this.texture = texture;
            this.renderer = renderer;
            this.srcRect = srcRect;
            this.destRect = destRect;
            this.parent = parent;
            parent.KeyPressed += OnKeyPressed;
            parent.MouseClicked += OnMouseClicked;
            parent.Render += Render;
        }
        new public IntPtr texture;
        protected ComponentID id;
    }
}