using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace J3P2_Monogame_Project.Framework
{
    public class Scene
    {
        protected SpriteBatch _spriteBatch;
        protected GraphicsDeviceManager _graphics;
        public Scene(SpriteBatch pSpriteBatch, GraphicsDeviceManager pGraphics, float pScale)
        {
            
        }
        public virtual void Update(GameTime pGameTime)
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
