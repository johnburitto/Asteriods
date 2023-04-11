using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace Core
{
    public class TextRenderer
    {
        private static string _alphabet = "-0123456789";
        public static List<TextElement> Alphabet = new()
        {
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, 0f),
                    new Vector2(10f, 0f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, -20f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(10f, -20f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-5f, 15f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(10f, -20f),
                    new Vector2(-10f, -20f),
                    new Vector2(-10f, -20f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, -20f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(10f, 20f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, -20f),
                    new Vector2(-10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, 0f),
                    new Vector2(10f, 0f),
                    new Vector2(-10f, 0f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(10f, -20f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, -20f),
                    new Vector2(-10f, -20f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(10f, 0f)
                }
            },
            new TextElement()
            {
                Points = new()
                {
                    new Vector2(-10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, -20f),
                    new Vector2(10f, 20f),
                    new Vector2(10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 20f),
                    new Vector2(-10f, 0f),
                    new Vector2(-10f, 0f),
                    new Vector2(10f, 0f),
                }
            }
        };

        public static void RenderText(GameWindow window, string text, float x, float y)
        {
            float xStep = 30;

            for (int i = 0; i < text.Length; i++)
            {
                var nextChar = Alphabet[_alphabet.IndexOf(text[i])];

                nextChar.Position.X = x + xStep * i;
                nextChar.Position.Y = y;

                PrimitiveRenderer.RenderLine(nextChar, window);
            }
        }
    }

    public class TextElement : GameObject
    {

    }
}
