using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Knight : GameObject
    {


        public Texture2D _textureKnight;
        public Texture2D _textureKnightShield;
        public Texture2D _textureKnightWeapon;
        public Texture2D _textureKnightWeaponShield;
        private Texture2D _textureHeart;
        private float _positionSpeed;
        public List<Heart> _hearts = new List<Heart>();


        public Knight(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics) : base(sceneManager, position, graphics)
        {
            _positionSpeed = 300f;
            Hearts(_graphics);

        }

        public override void LoadObject(ContentManager content)
        {
            _textureKnight = content.Load<Texture2D>("Knight");
            _textureKnightShield = content.Load<Texture2D>("KnightShield");
            _textureKnightWeapon = content.Load<Texture2D>("KnightWeapon");
            _textureKnightWeaponShield = content.Load<Texture2D>("KnightWeaponShield");
            _textureHeart = content.Load<Texture2D>("heart");

            _texture = _textureKnight;
            _center = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);
           
        }
        public void Movement(GameTime gameTime)
        {
            Vector2 dir = Vector2.Zero;
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W))
            {
                dir.Y -= 1;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                dir.Y += 1;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                dir.X -= 1;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                dir.X += 1;
            }
            if (dir != Vector2.Zero)
            {
                dir.Normalize();
            }
            _position += dir * _positionSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void changeTexture(bool sword)
        {
            if (sword)
            {
                if (_texture == _textureKnightShield)
                {
                    _texture = _textureKnightWeaponShield;
                }
                else
                {
                    _texture = _textureKnightWeapon;
                }
            }
            else
            {
                if (_texture == _textureKnightWeapon)
                {
                    _texture = _textureKnightWeaponShield;
                }
                else
                {
                    _texture = _textureKnightShield;
                }
            }
            
        }
        public void newPosition()
        {
            _position = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2);
        }

        public virtual void Hearts(GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < 3; i++)
            {
                float x = 30 + (50 * i);
                float y = 30;
                _hearts.Add(new Heart(_sceneManager, new Vector2(x, y), graphics));
                Console.WriteLine(_hearts[i]._texture);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            _sceneManager.GetCurrentScene()._hearts = _hearts;
        }
    }
}
