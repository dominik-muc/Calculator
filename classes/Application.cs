using SDL2;

namespace Calculator
{
    public class Application
    {
        public Application()
        {

        }
        public void Init(string title, int x, int y, int w, int h)
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING); //todo: change flags to optimize
            window = SDL.SDL_CreateWindow(title, x, y, w, h, 0);
            renderer = SDL.SDL_CreateRenderer(window, -1, 0);
        }
        public void Run()
        {
            isAlive = true;
            while(isAlive)
            {
                HandleEvents();
                Update();
            }
        }
        public void CreateNewComponent(ComponentID id, ComponentType type, string texturePath, SDL.SDL_Rect srcRect, SDL.SDL_Rect destRect)
        {
            switch(type)
            {
                case ComponentType.COMPONENT_BUTTON:
                    visibleComponents.Add(id, new Button(LoadTexture(texturePath), renderer, srcRect, destRect));
                    Render += visibleComponents[id].Render;
                    break;
            }
        }
        public void UpdateRequest() => Update();
        public event EventHandler<MouseClickedEventArgs>? MouseClicked;
        protected virtual void OnMouseClicked(MouseClickedEventArgs e) => MouseClicked?.Invoke(this, e);
        public event EventHandler<KeyPressedEventArgs>? KeyPressed; //TODO Segregate events and invokes (readibility)
        protected virtual void OnKeyPressed(KeyPressedEventArgs e) => KeyPressed?.Invoke(this, e);
        public event EventHandler<RenderEventArgs>? Render;
        protected virtual void OnRender(RenderEventArgs e) => Render?.Invoke(this, e);
        protected void HandleEvents()
        {
            SDL.SDL_PollEvent(out lastEvent);
            switch(lastEvent.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    Quit();
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    switch(lastEvent.button.which)
                    {
                        case SDL.SDL_BUTTON_LEFT:
                            OnMouseClicked(new MouseClickedEventArgs(new Point(lastEvent.button.x, lastEvent.button.y)));
                            break;
                    }
                    break;
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    OnKeyPressed(new KeyPressedEventArgs(lastEvent.key.keysym.sym));
                    break;
                default:
                    break;
            }
        }
        protected void Update()
        {
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
            OnRender(new RenderEventArgs(renderer));
            SDL.SDL_RenderPresent(renderer);
        }
        protected void Quit()
        {
            isAlive = false;
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_DestroyRenderer(renderer);
            //todo destroy textures here!!
            SDL.SDL_Quit();
        }
        protected IntPtr LoadTexture(string texturePath)
        {
            IntPtr tempsurf = SDL_image.IMG_Load(texturePath);
            IntPtr texture = SDL.SDL_CreateTextureFromSurface(renderer, tempsurf);
            SDL.SDL_FreeSurface(tempsurf);
            return texture;

        }
        protected SDL.SDL_Event lastEvent;
        protected IntPtr window;
        protected IntPtr renderer;
        protected bool isAlive = false;
        protected Dictionary<ComponentID, IVisible> visibleComponents = new Dictionary<ComponentID, IVisible>();
    }
}