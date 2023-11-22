using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace J3P2_Monogame_Project.Framework
{
    class Scene
    {
        protected SpriteBatch _spriteBatch;
        protected GraphicsDeviceManager _graphics;
        protected Vector2 _scale;
        public Scene(SpriteBatch pSpriteBatch, GraphicsDeviceManager pGraphics, Vector2 pScale)
        {
            _scale= pScale;
            _spriteBatch = pSpriteBatch;
            _graphics = pGraphics;
        }
        public virtual void Update()
        {
            
        }

        public virtual void Draw(GameTime gameTime)
        {
            
        }

        public virtual void LoadContent(SceneManager sceneManager)
        {

        }
    }
}
