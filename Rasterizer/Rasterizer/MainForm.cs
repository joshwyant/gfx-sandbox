using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Math3D;

namespace Rasterizer
{
    public partial class MainForm : Form
    {
        /*
        struct Vector2
        {
            public float X;
            public float Y;
            public Vector2(float x, float y)
            {
                X = x;
                Y = y;
            }
            public float Dot(Vector2 b)
            {
                return X*b.X+Y*b.Y;
            }
            public static float Dot(Vector2 a, Vector2 b)
            {
                return a.X * b.X + a.Y * b.Y;
            }
            public float Length
            {
                get
                {
                    return (float)Math.Sqrt(X * X + Y * Y);
                }
                set
                {
                    float l = (float)Math.Sqrt(X * X + Y * Y);
                    X = X / l * value;
                    Y = Y / l * value;
                }
            }
            public float LengthSq
            {
                get
                {
                    return X * X + Y * Y;
                }
            }
            public Vector2 Normal
            {
                get
                {
                    float r_l = 1.0f / (float)Math.Sqrt(X * X + Y * Y);
                    return new Vector2(X * r_l, Y * r_l);
                }
            }
            public void Normalize()
            {
                float r_l = 1.0f / (float)Math.Sqrt(X * X + Y * Y);
                X *= r_l;
                Y *= r_l;
            }
            public static Vector2 Lerp(float a, Vector2 x, Vector2 y)
            {
                float inva = 1.0f - a;
                return new Vector2(
                    inva * x.X + a * y.X,
                    inva * x.Y + a * y.Y
                    );
            }
            public void Scale(float s)
            {
                X *= s;
                Y *= s;
            }
            public static Vector2 Scale(Vector2 v, float s)
            {
                return new Vector2(v.X * s, v.Y * s);
            }
            public void Add(Vector2 v)
            {
                X += v.X;
                Y += v.Y;
            }
            public void Subtract(Vector2 v)
            {
                X -= v.X;
                Y -= v.Y;
            }
            public static Vector2 Add(Vector2 a, Vector2 b)
            {
                return new Vector2(a.X + b.X, a.Y + b.Y);
            }
            public static Vector2 Subtract(Vector2 a, Vector2 b)
            {
                return new Vector2(a.X - b.X, a.Y - b.Y);
            }
        }
        struct Vector3
        {
            public float X;
            public float Y;
            public float Z;
            public Vector3(float x, float y, float z)
            {
                X = x;
                Y = y;
                Z = z;
            }
            public float Dot(Vector3 b)
            {
                return X * b.X + Y * b.Y + Z * b.Z;
            }
            public static float Dot(Vector3 a, Vector3 b)
            {
                return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
            }
            public float Length
            {
                get
                {
                    return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
                }
                set
                {
                    float l = (float)Math.Sqrt(X * X + Y * Y + Z * Z);
                    X = X / l * value;
                    Y = Y / l * value;
                    Z = Z / l * value;
                }
            }
            public float LengthSq
            {
                get
                {
                    return X * X + Y * Y + Z * Z;
                }
            }
            public Vector3 Normal
            {
                get
                {
                    float r_l = 1.0f / (float)Math.Sqrt(X * X + Y * Y + Z * Z);
                    return new Vector3(X * r_l, Y * r_l, Z * r_l);
                }
            }
            public void Normalize()
            {
                float r_l = 1.0f / (float)Math.Sqrt(X * X + Y * Y + Z * Z);
                X *= r_l;
                Y *= r_l;
                Z *= r_l;
            }
            public static Vector3 Lerp(float a, Vector3 x, Vector3 y)
            {
                float inva = 1.0f - a;
                return new Vector3(
                    inva * x.X + a * y.X,
                    inva * x.Y + a * y.Y,
                    inva * x.Z + a * y.Z
                    );
            }
            public void Scale(float s)
            {
                X *= s;
                Y *= s;
                Z *= s;
            }
            public static Vector3 Scale(Vector3 v, float s)
            {
                return new Vector3(v.X * s, v.Y * s, v.Z * s);
            }
            public void Add(Vector3 v)
            {
                X += v.X;
                Y += v.Y;
                Z += v.Z;
            }
            public void Subtract(Vector3 v)
            {
                X -= v.X;
                Y -= v.Y;
                Z -= v.Z;
            }
            public static Vector3 Add(Vector3 a, Vector3 b)
            {
                return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            }
            public static Vector3 Subtract(Vector3 a, Vector3 b)
            {
                return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            }
        }
        struct Vector4
        {
            public float X;
            public float Y;
            public float Z;
            public float W;
            public Vector4(float x, float y, float z, float w)
            {
                X = x;
                Y = y;
                Z = z;
                W = w;
            }
            public float Dot(Vector4 b)
            {
                return X * b.X + Y * b.Y + Z * b.Z + W * b.W;
            }
            public static float Dot(Vector4 a, Vector4 b)
            {
                return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
            }
            public float Length
            {
                get
                {
                    return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
                }
                set
                {
                    float l = (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
                    X = X / l * value;
                    Y = Y / l * value;
                    Z = Z / l * value;
                    W = W / l * value;
                }
            }
            public float LengthSq
            {
                get
                {
                    return X * X + Y * Y + Z * Z + W * W;
                }
            }
            public Vector4 Normal
            {
                get
                {
                    float r_l = 1.0f / (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
                    return new Vector4(X * r_l, Y * r_l, Z * r_l, W * r_l);
                }
            }
            public void Normalize()
            {
                float r_l = 1.0f / (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
                X *= r_l;
                Y *= r_l;
                Z *= r_l;
                W *= r_l;
            }
            public static Vector4 Lerp(float a, Vector4 x, Vector4 y)
            {
                float inva = 1.0f - a;
                return new Vector4(
                    inva * x.X + a * y.X,
                    inva * x.Y + a * y.Y,
                    inva * x.Z + a * y.Z,
                    inva * x.W + a * y.W
                    );
            }
            public void Scale(float s)
            {
                X *= s;
                Y *= s;
                Z *= s;
                W *= s;
            }
            public static Vector4 Scale(Vector4 v, float s)
            {
                return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
            }
            public void Add(Vector4 v)
            {
                X += v.X;
                Y += v.Y;
                Z += v.Z;
                W += v.W;
            }
            public void Subtract(Vector4 v)
            {
                X -= v.X;
                Y -= v.Y;
                Z -= v.Z;
                W -= v.W;
            }
            public static Vector4 Add(Vector4 a, Vector4 b)
            {
                return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
            }
            public static Vector4 Subtract(Vector4 a, Vector4 b)
            {
                return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
            }
        }
        */
        Bitmap buffer;
        Graphics g;
        float scale = antialiased ? 3.0f : 1.0f;
        System.Drawing.Imaging.BitmapData bd;
        System.Drawing.Imaging.BitmapData tex = null;
        Bitmap _tex = null;
        bool culling = true; // Whether to use backface culling
        bool uvclamp = true; // Either clamp UV coords or wrap them.
        bool texlinear = true; // Whether to use a linear texture filter.
        bool blendalpha = true; // Whether to enable alpha testing.
        bool blendvertex = true; // Whether to blend colors between vertices
        const bool antialiased = false; // Whether full-scene anti-aliasing is enabled.
        bool texenable = true; // Whether to use textures.
        //bool perspective_correct = true; // Whether to use perspective-correct or affine texture coordinates.
        bool ztest = false; // Whether to use the Z buffer.
        float minz = 1; // The minimum Z for clipping
        float maxz = 1000; // The maximum Z for clipping
        bool normalize_normals = false;
        Matrix world;
        Matrix view;
        Matrix projection;
        Point mp;
        Point p1 = new Point(32, 16);
        Point p2 = new Point(16, 256);
        Point p3 = new Point(256, 128);
        Size s1 = new Size(4, 4);
        Size s2 = new Size(3, -3);
        Size s3 = new Size(-5, 5);
        unsafe float* depth;
        int frames;
        int delta;
        public MainForm()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.Opaque |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
            buffer = new Bitmap(ClientSize.Width * (int)scale, ClientSize.Height * (int)scale, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            g = Graphics.FromImage(buffer);
            this.ClientSize = new Size(320, 240);
            unsafe
            {
                depth = (float*)System.Runtime.InteropServices.Marshal.AllocHGlobal(buffer.Width * buffer.Height * sizeof(float));//new float[buffer.Width*buffer.Height];
            }
            delta = System.Environment.TickCount + 1000;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            UpdateImage();
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.DrawImage(buffer, 0, 0, ClientSize.Width, ClientSize.Height);
            this.Invalidate();
        }
        private void BeginDraw()
        {
            bd = buffer.LockBits(new Rectangle(Point.Empty, buffer.Size), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        }
        private void EndDraw()
        {
            if (tex != null)
                _tex.UnlockBits(tex);
            tex = null;
            _tex = null;
            buffer.UnlockBits(bd);
        }

        private unsafe void DrawLine(Point p1, Point p2, int c)
        {
            int* ptr = (int*)bd.Scan0.ToPointer();
            bool steep = Math.Abs(p2.Y - p1.Y) > Math.Abs(p2.X - p1.X);
            int w, h;
            if (steep)
            {
                int t;
                t = p1.X;
                p1.X = p1.Y;
                p1.Y = t;
                t = p2.X;
                p2.X = p2.Y;
                p2.Y = t;
                w = buffer.Height;
                h = buffer.Width;
            }
            else
            {
                w = buffer.Width;
                h = buffer.Height;
            }
            if (p1.X > p2.X)
            {
                Point t = p1;
                p1 = p2;
                p2 = t;
            }
            int deltax = p2.X - p1.X;
            int deltay = Math.Abs(p2.Y - p1.Y);
            float error = 0.0f;
            float deltaerr = (float)deltay / (float)deltax;
            int ystep;
            int y = p1.Y;
            if (p1.Y < p2.Y) ystep = 1; else ystep = -1;
            for (int x = Math.Max(0, p1.X); x < p2.X && x < w; x++)
            {
                if (y >= 0 && y < h)
                {
                    if (steep)
                        *(ptr + x * bd.Width + y) = c;
                    else
                        *(ptr + y * bd.Width + x) = c;
                }
                error += deltaerr;
                if (error >= 0.5f)
                {
                    y += ystep;
                    error -= 1.0f;
                }
            }
        }

        private unsafe void DrawTriangle(Point[] p, Color[] c)
        {
            int t = 0; // Top point index
            if (p[1].Y < p[t].Y) t = 1;
            if (p[2].Y < p[t].Y) t = 2;
            int b = 0; // Bottom point index
            if (p[1].Y > p[b].Y) b = 1;
            if (p[2].Y > p[b].Y) b = 2;
            int m = 0; // Middle point index
            if (t != 1 && b != 1) m = 1;
            if (t != 2 && b != 2) m = 2;
            bool two = // whether to draw 2 triangles (opposite a Y coordinate)
                p[0].Y != p[1].Y &&
                p[1].Y != p[2].Y &&
                p[2].Y != p[0].Y;
            float s1, s2; // the two slopes
            int col = c[0].ToArgb();
            int* ptr = (int*)bd.Scan0.ToPointer(); // The pointer to start of bitmap
            if (p[t].Y != p[m].Y)
            {
                s1 = (float)(p[m].X - p[t].X) / (float)(p[m].Y - p[t].Y);
                s2 = (float)(p[b].X - p[t].X) / (float)(p[b].Y - p[t].Y);
                for (int i = p[t].Y; i < p[m].Y && i < buffer.Height; i++)
                {
                    int A = float.IsInfinity(s1) ? p[t].X : p[t].X + (int)(((float)(i - p[t].Y) * s1));
                    int B = float.IsInfinity(s2) ? p[t].X : p[t].X + (int)(((float)(i - p[t].Y) * s2));
                    int x1 = Math.Min(A, B);
                    int x2 = Math.Max(A, B);
                    for (int j = x1; j < x2 && j < buffer.Width; j++)
                    {
                        float CA = (float)(j - p[t].Y) / (float)(p[m].Y - p[t].Y);
                        float CB = (float)(j - p[b].Y) / (float)(p[b].Y - p[t].Y);
                        
                        *(ptr + j + i * bd.Width) = col;
                    }
                }
                if (!two) return;
            }
            s1 = (float)(p[t].X - p[b].X) / (float)(p[t].Y - p[b].Y);
            s2 = (float)(p[m].X - p[b].X) / (float)(p[m].Y - p[b].Y);
            for (int i = p[m].Y; i < p[b].Y && i < buffer.Height; i++)
            {
                int A = float.IsInfinity(s1) ? p[t].X : p[t].X + (int)(((float)(i - p[t].Y) * s1));
                int B = float.IsInfinity(s2) ? p[m].X : p[m].X + (int)(((float)(i - p[m].Y) * s2));
                int x1 = Math.Min(A, B);
                int x2 = Math.Max(A, B);
                for (int j = x1; j < x2 && j < buffer.Width; j++)
                    *(ptr + j + i * bd.Width) = col;
            }
        }

        float lerp(float a, float x, float y)
        {
            return (1 - a) * x + a * y;
        }

        //Vector2 UV(Vector2 uv1, Vector2 uv2, Vector3 v1, Vector3 v2, float a)
        //{
        //    if (perspective_correct)
        //        return UVPerspective(uv1, uv2, v1, v2, a);
        //    else
        //        return UVAffine(uv1, uv2, v1, v2, a);
        //}

        Vector2 UVAffine(Vector2 uv1, Vector2 uv2, Vector3 v1, Vector3 v2, float a)
        {
            return Vector2.Lerp(uv1, uv2, a);
        }

        Vector2 UVPerspective(Vector2 uv1, Vector2 uv2, Vector3 v1, Vector3 v2, float a)
        {
            return Vector2.Scale(
                Vector2.Lerp(
                    Vector2.Scale(uv1, 1.0f / v1.Z),
                    Vector2.Scale(uv2, 1.0f / v2.Z),a),
                1.0f / lerp(a, 1.0f / v1.Z, 1.0f / v2.Z)
                );
        }
        int merge(int c1, int c2, float a)
        {
            a = Math.Max(0.0f, Math.Min(1.0f, a));
            float b1 = (float)(c1 & 0xFF);
            float g1 = (float)((c1 >> 8) & 0xFF);
            float r1 = (float)((c1 >> 16) & 0xFF);
            float a1 = (float)((c1 >> 24) & 0xFF);
            float b2 = (float)(c2 & 0xFF);
            float g2 = (float)((c2 >> 8) & 0xFF);
            float r2 = (float)((c2 >> 16) & 0xFF);
            float a2 = (float)((c2 >> 24) & 0xFF);
            float inva = 1.0f-a;
            int A = (int)Math.Round(inva * a1 + a * a2);
            int R = (int)Math.Round(inva * r1 + a * r2);
            int G = (int)Math.Round(inva * g1 + a * g2);
            int B = (int)Math.Round(inva * b1 + a * b2);
            return (B | (G << 8) | (R << 16) | (A << 24));
        }

        int multiply(int col_from, int col_ref)
        {
            if (col_ref == 0) return 0;
            if (col_ref == -1) return col_from;
            const float inv255 = 1.0f / 255.0f;
            float b1 = (float)(col_from & 0xFF);
            float g1 = (float)((col_from >> 8) & 0xFF);
            float r1 = (float)((col_from >> 16) & 0xFF);
            float a1 = (float)((col_from >> 24) & 0xFF);
            float b2 = (float)(col_ref & 0xFF) * inv255;
            float g2 = (float)((col_ref >> 8) & 0xFF) * inv255;
            float r2 = (float)((col_ref >> 16) & 0xFF) * inv255;
            float a2 = (float)((col_ref >> 24) & 0xFF) * inv255;
            int A = (int)Math.Round(a1 * a2);
            int R = (int)Math.Round(r1 * r2);
            int G = (int)Math.Round(g1 * g2);
            int B = (int)Math.Round(b1 * b2);
            return (B | (G << 8) | (R << 16) | (A << 24));
        }

        // final alpha = unchanged
        unsafe void write_xrgb(int* c, int c2)
        {
            if (!blendalpha)
            {
                *c = (int)((uint)*c & 0xFF000000) | c2;
                return;
            }
            // Quick checks:
            switch (c2 & 0xFF000000)
            {
                case 0:
                    return;
                case 0xFF000000:
                    *c = (int)((uint)*c & 0xFF000000) | c2;
                    return;
            }
            float a = (float)((c2 >> 24) & 0xFF) / 255.0f;
            int c1 = *c;
            float b1 = (float)(c1 & 0xFF);
            float g1 = (float)((c1 >> 8) & 0xFF);
            float r1 = (float)((c1 >> 16) & 0xFF);
            float b2 = (float)(c2 & 0xFF);
            float g2 = (float)((c2 >> 8) & 0xFF);
            float r2 = (float)((c2 >> 16) & 0xFF);
            float inva = 1.0f - a;
            int R = (int)(inva * r1 + a * r2);
            int G = (int)(inva * g1 + a * g2);
            int B = (int)(inva * b1 + a * b2);
            *c = (B | (G << 8) | (R << 16) | (int)((uint)c1 & 0xFF000000));
        }

        // alpha blended (fixme, don't use)
        unsafe void write_argb(int* c, int c2)
        {
            /*float a = (float)((c2 >> 24) & 0xFF) / 255.0f;
            int c1 = *c;
            float b1 = (float)(c1 & 0xFF);
            float g1 = (float)((c1 >> 8) & 0xFF);
            float r1 = (float)((c1 >> 16) & 0xFF);
            float a1 = (float)((c1 >> 24) & 0xFF);
            float b2 = (float)(c2 & 0xFF);
            float g2 = (float)((c2 >> 8) & 0xFF);
            float r2 = (float)((c2 >> 16) & 0xFF);
            float a2 = (float)((c1 >> 24) & 0xFF);
            float inva = 1.0f - a;
            int R = (int)(inva * r1 + a * r2);
            int G = (int)(inva * g1 + a * g2);
            int B = (int)(inva * b1 + a * b2);
            *c = (B | (G << 8) | (R << 16) | ((int)lerp(a, a1, 1.0f) << 24));*/
        }

        unsafe int texcol_nearest(Vector2 uv)
        {
            if (tex == null) return unchecked((int)0xFFFFFFFF);
            uv.Y = 1.0f - uv.Y;
            int pitch = tex.Stride / tex.Width;
            int x, y;
            if (uvclamp)
            {
                x = Math.Min((int)Math.Floor(Math.Max(0.0f, Math.Min(1.0f, uv.X)) * (float)(tex.Width)), tex.Width - 1);
                y = Math.Min((int)Math.Floor(Math.Max(0.0f, Math.Min(1.0f, uv.Y)) * (float)(tex.Height)), tex.Height - 1);
            }
            else
            {
                x = (int)Math.Floor(((uv.X - (float)Math.Floor(uv.X)) % 1.0f) * (float)(tex.Width)) % tex.Width;
                y = (int)Math.Floor(((uv.Y - (float)Math.Floor(uv.Y)) % 1.0f) * (float)(tex.Height)) % tex.Height;
            }
            int oralpha = 0;
            if (tex.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                oralpha = unchecked((int)0xFF000000);
            if (pitch == 4)
                return *((int*)tex.Scan0.ToPointer() + bd.Width * y + x) | oralpha;
            else
            {
                byte* ptr = (byte*)tex.Scan0.ToPointer() + tex.Stride * y + x * pitch;
                return *(ptr++) | (*(ptr++) << 8) | (*(ptr++) << 16) | oralpha;
            }
        }
        unsafe int texcol_linear(Vector2 uv)
        {
            if (tex == null) return unchecked((int)0xFFFFFFFF);
            uv.Y = 1.0f - uv.Y;
            int pitch = tex.Stride / tex.Width;
            float x, y, xv, yv;
            int x1, y1, x2, y2;
            if (uvclamp)
            {
                x = Math.Max(0.0f, Math.Min(1.0f, uv.X)) * (float)(tex.Width);
                y = Math.Max(0.0f, Math.Min(1.0f, uv.Y)) * (float)(tex.Height);
                x1 = Math.Min((int)Math.Floor(x), tex.Width - 1);
                y1 = Math.Min((int)Math.Floor(y), tex.Height - 1);
                x2 = Math.Min((x1 + 1), tex.Width - 1);
                y2 = Math.Min((y1 + 1), tex.Height - 1);
            }
            else
            {
                x = ((uv.X - (float)Math.Floor(uv.X)) % 1.0f) * (float)(tex.Width);
                y = ((uv.Y - (float)Math.Floor(uv.Y)) % 1.0f) * (float)(tex.Height);
                x1 = (int)Math.Floor(x) % tex.Width;
                y1 = (int)Math.Floor(y) % tex.Height;
                x2 = (x1 + 1) % tex.Width;
                y2 = (y1 + 1) % tex.Height;
            }
            xv = x - (float)Math.Floor(x);
            yv = y - (float)Math.Floor(y);
            int oralpha = 0;
            if (tex.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                oralpha = unchecked((int)0xFF000000);
            if (pitch == 4)
            {
                int* iptr = (int*)tex.Scan0.ToPointer();
                int c1 = *(iptr + bd.Width * y1 + x1);
                int c2 = *(iptr + bd.Width * y1 + x2);
                int c3 = *(iptr + bd.Width * y2 + x1);
                int c4 = *(iptr + bd.Width * y2 + x2);
                return merge(merge(c1, c2, xv), merge(c3, c4, xv), yv) | oralpha;
            }
            else
            {
                byte* tptr = (byte*)tex.Scan0.ToPointer();
                byte* ptr = tptr + tex.Stride * y1 + x1 * pitch;
                int c1 = *(ptr++) | (*(ptr++) << 8) | (*(ptr++) << 16);
                ptr = tptr + tex.Stride * y1 + x2 * pitch;
                int c2 = *(ptr++) | (*(ptr++) << 8) | (*(ptr++) << 16);
                ptr = tptr + tex.Stride * y2 + x1 * pitch;
                int c3 = *(ptr++) | (*(ptr++) << 8) | (*(ptr++) << 16);
                ptr = tptr + tex.Stride * y2 + x2 * pitch;
                int c4 = *(ptr++) | (*(ptr++) << 8) | (*(ptr++) << 16);
                return merge(merge(c1, c2, xv), merge(c3, c4, xv), yv) | oralpha;
            }
        }
        void SetTexture(Bitmap Texture)
        {
            if (tex != null && _tex != Texture)
                _tex.UnlockBits(tex);
            if (Texture == null)
            {
                tex = null;
                _tex = null;
            }
            else
            {
                tex = Texture.LockBits(new Rectangle(0, 0, Texture.Width, Texture.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, Texture.PixelFormat);
                _tex = Texture;
            }
        }
        // Swaps any type T val1 with val2
        private void Swap<T>(ref T val1, ref T val2)
        {
            T val = val1;
            val1 = val2;
            val2 = val;
        }
        private unsafe void Triangle(Vector4[] v, Vector2[] uv, int[] c)
        {
            // The triangle is drawn in 2 halves: The top half and the bottom half.
            // It is drawn with a top-left filling convention using horizontal scanlines.
            // Determine the top, middle, and bottom vertex indices, in order of Y.
            int t = 0; // Top point index
            if (v[1].Y < v[t].Y) t = 1;
            if (v[2].Y < v[t].Y) t = 2;
            int b = 0; // Bottom point index
            if (v[1].Y > v[b].Y) b = 1;
            if (v[2].Y > v[b].Y) b = 2;
            int m = 0; // Middle point index
            if (t != 1 && b != 1) m = 1;
            if (t != 2 && b != 2) m = 2;
            int* ptr = (int*)bd.Scan0.ToPointer(); // The pointer to start of bitmap
            // Vertex indices for the current half:
            int t1 = t, // left edge top vertex
                t2 = t, // right edge top vertex
                b1 = m, // left edge bottom vertex
                b2 = b, // right edge bottom vertex
                it = t, // top of half
                ib = m; // bottom of half
            // Draw 2 halves
            for (int half = 1; half <= 2; half++)
            {
                // Calculate left and right slopes. Our formula: x = my + b
                float s1 = (v[b1].X - v[t1].X) / (v[b1].Y - v[t1].Y); // left edge slope
                float s2 = (v[b2].X - v[t2].X) / (v[b2].Y - v[t2].Y); // right edge slope
                // Calculate Y range
                float miny = Math.Max((float)Math.Ceiling(v[it].Y), 0.0f);
                float maxy = Math.Min((float)Math.Ceiling(v[ib].Y), buffer.Height);
                for (float i = miny; i < maxy; i++)
                {
                    int inti = (int)i; // The integer representing the scanline's Y coordinate
                    // The points making our left and right edges from our main vertex
                    // Get values along both edges
                    // The edges' start and end X
                    float fA = v[t1].X + ((i - v[t1].Y) * s1);
                    float fB = v[t2].X + ((i - v[t2].Y) * s2);
                    // Determine left and right edge
                    if (fB < fA)
                    {
                        // Swap:
                        Swap<float>(ref s1, ref s2); // Left and right slopes
                        Swap<float>(ref fA, ref fB); // Scanline start and end X
                        Swap<int>(ref t1, ref t2); // Left and right edges' top vertex indices
                        Swap<int>(ref b1, ref b2); // Left and right edges' bottom vertex indices
                    }
                    // Scanline's start and end
                    float A = Math.Max((float)Math.Ceiling(fA), 0.0f);
                    float B = Math.Min((float)Math.Ceiling(fB), buffer.Width);
                    int iA = (int)A; // Convert to integers
                    int iB = (int)B;
                    float d1 = (i - v[t1].Y) / (v[b1].Y - v[t1].Y); // The distance down the edges from 0 to 1
                    float d2 = (i - v[t2].Y) / (v[b2].Y - v[t2].Y);
                    // Interpolate W and Z along the edges
                    float w1, w2, z1, z2, cd1 = 0, cd2 = 0;
                    //if (perspective_correct)
                    //{
                        cd1 = d1 / ((1.0f - d1) * v[t1].W + d1 * v[b1].W) * v[b1].W; // perspective correct values
                        cd2 = d2 / ((1.0f - d2) * v[t2].W + d2 * v[b2].W) * v[b2].W;
                    //}
                    //else
                    //{
                    //    cd1 = d1;
                    //    cd2 = d2;
                    //}
                    w1 = lerp(cd1, 1.0f / v[t1].W, 1.0f / v[b1].W);
                    w2 = lerp(cd2, 1.0f / v[t2].W, 1.0f / v[b2].W);
                    z1 = lerp(cd1, v[t1].Z / v[t1].W, v[b1].Z / v[b1].W);
                    z2 = lerp(cd2, v[t2].Z / v[t2].W, v[b2].Z / v[b2].W);
                    Vector2 uv1 = Vector2.Lerp(uv[t1], uv[b1], cd1); // The UV coordinates on both edges
                    Vector2 uv2 = Vector2.Lerp(uv[t2], uv[b2], cd2);
                    // Blend the colors
                    int c1 = 0, c2 = 0;
                    if (blendvertex)
                    {
                        c1 = merge(c[t1], c[b1], cd1);
                        c2 = merge(c[t2], c[b2], cd2);
                    }
                    for (float j = A; j < B; j++)
                    {
                        int intj = (int)j;
                        float p = (j - fA) / (fB - fA);
                        float cpw = //perspective_correct ?
                            p / (((1.0f - p) / w1 + p / w2)) / w2;// : p; // the distance, 0-1, in Z, between v1 and v2
                        float z = lerp(cpw, z1, z2) / lerp(cpw, w1, w2);
                        if (ztest)
                        {
                            float* dptr = depth + inti * buffer.Width + intj;
                            if (*dptr < z) continue;
                            *dptr = z;
                        }
                        int tc = texenable ? texlinear ?
                            texcol_linear(Vector2.Lerp(uv1, uv2, cpw)) :
                            texcol_nearest(Vector2.Lerp(uv1, uv2, cpw)) : unchecked((int)0xFFFFFFFF);

                        //write_xrgb(ptr + intj + inti * bd.Width, multiply(tc, blendvertex ? merge(c1, c2, cp) : c[0]));
                        int* pixel = ptr + intj + inti * bd.Width;
                        int pixcol = multiply(tc, blendvertex ? merge(c1, c2, cpw) : c[0]);
                        if ((!blendalpha) || ((pixcol & 0xFF000000) == 0xFF000000))
                            *pixel = (int)((uint)*pixel & 0xFF000000) | pixcol;
                        else if ((pixcol & 0xFF000000) != 0)
                        {
                            float a = (float)((c2 >> 24) & 0xFF) / 255.0f;
                            int pixcol1 = *pixel;
                            float pb1 = (float)(pixcol1 & 0xFF);
                            float pg1 = (float)((pixcol1 >> 8) & 0xFF);
                            float pr1 = (float)((pixcol1 >> 16) & 0xFF);
                            float pb2 = (float)(pixcol & 0xFF);
                            float pg2 = (float)((pixcol >> 8) & 0xFF);
                            float pr2 = (float)((pixcol >> 16) & 0xFF);
                            float inva = 1.0f - a;
                            int pr = (int)(inva * pr1 + a * pr2);
                            int pg = (int)(inva * pg1 + a * pg2);
                            int pb = (int)(inva * pb1 + a * pb2);
                            *pixel = (pb | (pg << 8) | (pr << 16) | (int)((uint)pixcol1 & 0xFF000000));
                        }
                    }
                }
                // Change the vertex indices for the next half
                t1 = t; t2 = m; b1 = b; b2 = b; it = m; ib = b;
            }
        }

        Vector3 pv(Point p)
        {
            return new Vector3((float)p.X, (float)p.Y, 1.0f);
        }
        int angle = 0;
        private void UpdateImage()
        {
            if (System.Environment.TickCount >= delta)
            {
                Text = string.Format("FPS: {0}", frames);
                frames = 0;
                delta = System.Environment.TickCount + 1000;
            }
            frames++;
            if (p1.X + s1.Width > buffer.Width / scale || p1.X + s1.Width < 0) s1.Width = -s1.Width;
            if (p2.X + s2.Width > buffer.Width / scale|| p2.X + s2.Width < 0) s2.Width = -s2.Width;
            if (p3.X + s3.Width > buffer.Width / scale || p3.X + s3.Width < 0) s3.Width = -s3.Width;
            if (p1.Y + s1.Height > buffer.Height / scale || p1.Y + s1.Height < 0) s1.Height = -s1.Height;
            if (p2.Y + s2.Height > buffer.Height / scale || p2.Y + s2.Height < 0) s2.Height = -s2.Height;
            if (p3.Y + s3.Height > buffer.Height / scale || p3.Y + s3.Height < 0) s3.Height = -s3.Height;
            p1.Offset(s1.Width, s1.Height);
            p2.Offset(s2.Width, s2.Height);
            p3.Offset(s3.Width, s3.Height);
            angle += 6;
            view = Matrix.LookAtLH(new Vector3(25,20.0f,25), Vector3.Empty, new Vector3(0, 1, 0));
            projection = 
                //Matrix.OrthoLH(160*buffer.Width/buffer.Height,160,minz,maxz);
                Matrix.PerspectiveFovLH(45.0f * (float)Math.PI / 180.0f, (float)buffer.Width / (float)buffer.Height, minz, maxz);
            BeginDraw();
            Clear(Color.Black.ToArgb(), 1.0f);
            Vector2[] t1 = new Vector2[] {
                    new Vector2(0,0),
                    new Vector2(1,0),
                    new Vector2(0,1),
                };
            int[] c1 = new int[] {
                    Color.FromArgb(128, Color.Red).ToArgb(),
                    Color.FromArgb(128, Color.Green).ToArgb(),
                    Color.FromArgb(128, Color.Yellow).ToArgb(),
                };
            Vector2[] t2 = new Vector2[] {
                    new Vector2(1,0),
                    new Vector2(1,1),
                    new Vector2(0,1),
                };
            int[] c2 = new int[] {
                    Color.FromArgb(128, Color.Green).ToArgb(),
                    Color.FromArgb(128, Color.Blue).ToArgb(),
                    Color.FromArgb(128, Color.Yellow).ToArgb(),
                };
            int[] c = new int[] {
                Color.FromArgb(128, Color.Red).ToArgb(),
                Color.FromArgb(128, Color.Green).ToArgb(),
                Color.FromArgb(128, Color.Blue).ToArgb(),
                Color.FromArgb(128, Color.Yellow).ToArgb(),
            };
            Vector2[] uv = new Vector2[] {
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(0,0),
            };
            // floor
            /**/
            const int flooruv = 100;
            const int floorval = 1000;
            world = Matrix.RotationY((float)angle * (float)Math.PI / 180.0f);
            SetTexture(Properties.Resources.Tile);
            uvclamp = false;
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(-floorval,-5,-floorval),
                    new Vector3(-floorval,-5,floorval),
                    new Vector3(floorval,-5,floorval),},
                new Vector2[] { Vector2.Scale(uv[0], flooruv), Vector2.Scale(uv[1], flooruv), Vector2.Scale(uv[2], flooruv) }, new int[] { Color.White.ToArgb(), Color.White.ToArgb(), Color.White.ToArgb() });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(-floorval,-5,-floorval),
                    new Vector3(floorval,-5,floorval),
                    new Vector3(floorval,-5,-floorval),},
                new Vector2[] { Vector2.Scale(uv[0], flooruv), Vector2.Scale(uv[2], flooruv), Vector2.Scale(uv[3], flooruv) }, new int[] { Color.White.ToArgb(), Color.White.ToArgb(), Color.White.ToArgb() });
            //*/
            world = Matrix.RotationY((float)angle * (float)Math.PI / 180.0f);// *Matrix.RotationZ(-20.0f * (float)Math.PI / 180.0f);// *Matrix.RotationY(-45.0f * (float)Math.PI / 180.0f);
            SetTexture(Properties.Resources.ChecksBig);
            uvclamp = true;
            // Bottom
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,-5,-5),
                    new Vector3(5,-5,5),
                    new Vector3(-5,-5,5),},
                new Vector2[] {uv[0], uv[1], uv[2]}, new int[] { c[0], c[1], c[2] });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,-5,-5),
                    new Vector3(-5,-5,5),
                    new Vector3(-5,-5,-5),},
                new Vector2[] { uv[0], uv[2], uv[3] }, new int[] { c[0], c[2], c[3] });
            // X+
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,5,-5),
                    new Vector3(5,5,5),
                    new Vector3(5,-5,5),},
                new Vector2[] { uv[0], uv[1], uv[2] }, new int[] { c[3], c[2], c[1] });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,5,-5),
                    new Vector3(5,-5,5),
                    new Vector3(5,-5,-5),},
                new Vector2[] { uv[0], uv[2], uv[3] }, new int[] { c[3], c[1], c[0] });
            // X-
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(-5,-5,-5),
                    new Vector3(-5,-5,5),
                    new Vector3(-5,5,5),},
                new Vector2[] { uv[0], uv[1], uv[2] }, new int[] { c[3], c[2], c[1] });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(-5,-5,-5),
                    new Vector3(-5,5,5),
                    new Vector3(-5,5,-5),},
                new Vector2[] { uv[0], uv[2], uv[3] }, new int[] { c[3], c[1], c[0] });
            // Z+
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,5,5),
                    new Vector3(-5,5,5),
                    new Vector3(-5,-5,5),},
                new Vector2[] { uv[0], uv[1], uv[2] }, new int[] { c[3], c[2], c[1] });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,5,5),
                    new Vector3(-5,-5,5),
                    new Vector3(5,-5,5),},
                new Vector2[] { uv[0], uv[2], uv[3] }, new int[] { c[3], c[1], c[0] });
            // Z-
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,-5,-5),
                    new Vector3(-5,-5,-5),
                    new Vector3(-5,5,-5),},
                new Vector2[] { uv[0], uv[1], uv[2] }, new int[] { c[3], c[2], c[1] });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(5,-5,-5),
                    new Vector3(-5,5,-5),
                    new Vector3(5,5,-5),},
                new Vector2[] { uv[0], uv[2], uv[3] }, new int[] { c[3], c[1], c[0] });
            // Top
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(-5,5,-5),
                    new Vector3(-5,5,5),
                    new Vector3(5,5,5),},
                new Vector2[] { uv[0], uv[1], uv[2] }, new int[] { c[0], c[1], c[2] });
            TransformedTriangle(
                new Vector3[] {
                    new Vector3(-5,5,-5),
                    new Vector3(5,5,5),
                    new Vector3(5,5,-5),},
                new Vector2[] { uv[0], uv[2], uv[3] }, new int[] { c[0], c[2], c[3] });
            //DrawLine(new Point(160*(int)scale, 120*(int)scale), new Point(mp.X*(int)scale, mp.Y*(int)scale), Color.White.ToArgb());
            EndDraw();
        }

        private void TransformedTriangle(Vector3[] v, Vector2[] uv, int[] c)
        {
            Matrix vm = Matrix.Identity; // Viewport matrix
            vm.M11 = (float)buffer.Width * 0.5f;
            vm.M22 = -(float)buffer.Height * 0.5f;
            vm.M41 = (float)buffer.Width * 0.5f;
            vm.M42 = (float)buffer.Height * 0.5f;
            Matrix WorldViewProjViewport = world * view * projection * vm;
            Vector4 v1 = Vector3.TransformCoordinate(v[0], WorldViewProjViewport);
            Vector4 v2 = Vector3.TransformCoordinate(v[1], WorldViewProjViewport);
            Vector4 v3 = Vector3.TransformCoordinate(v[2], WorldViewProjViewport);
            if (v1.W > 0 && v2.W > 0 && v3.W > 0)
            {
                float invw1 = 1.0f / v1.W;
                float invw2 = 1.0f / v2.W;
                float invw3 = 1.0f / v3.W;
                Vector4 tv1 = new Vector4(v1.X * invw1, v1.Y * invw1, v1.Z * invw1, 1.0f * invw1);
                Vector4 tv2 = new Vector4(v2.X * invw2, v2.Y * invw2, v2.Z * invw2, 1.0f * invw2);
                Vector4 tv3 = new Vector4(v3.X * invw3, v3.Y * invw3, v3.Z * invw3, 1.0f * invw3);
                if (culling) if (Vector3.Cross(new Vector3(tv2.X - tv1.X, tv1.Y - tv2.Y, 0), new Vector3(tv3.X - tv1.X, tv1.Y - tv3.Y, 0)).Z >= 0) return;
                Triangle(new Vector4[] { tv1, tv2, tv3 }, uv, c);
            }
            else
            {
                int[] tv = new int[3]; // The vertices to be clipped
                int[] tvn = new int[3]; // The vertices not to be clipped
                int tvc = 0;
                int tvnc = 0;
                Vector4[] tva = new Vector4[] { v1, v2, v3 };
                Vector2[] tuv = new Vector2[] { uv[0], uv[1], uv[2] };
                int[] tc = new int[] { c[0], c[1], c[2] };
                if (v1.Z <= 0) tv[tvc++] = 0; else tvn[tvnc++] = 0;
                if (v2.Z <= 0) tv[tvc++] = 1; else tvn[tvnc++] = 1;
                if (v3.Z <= 0) tv[tvc++] = 2; else tvn[tvnc++] = 2;
                if (tvnc == 0) return;
                if (tvnc == 1)
                {
                    float a1 = tva[tvn[0]].Z / (tva[tvn[0]].Z - tva[tv[0]].Z);
                    float a2 = tva[tvn[0]].Z / (tva[tvn[0]].Z - tva[tv[1]].Z);
                    tva[tv[0]] = Vector4.Lerp(tva[tvn[0]], tva[tv[0]], a1);
                    tva[tv[1]] = Vector4.Lerp(tva[tvn[0]], tva[tv[1]], a2);
                    tuv[tv[0]] = Vector2.Lerp(tuv[tvn[0]], tuv[tv[0]], a1);
                    tuv[tv[1]] = Vector2.Lerp(tuv[tvn[0]], tuv[tv[1]], a2);
                    if (blendvertex)
                    {
                        tc[tv[1]] = merge(tc[tvn[0]], tc[tv[0]], a1);
                        tc[tv[2]] = merge(tc[tvn[0]], tc[tv[1]], a2);
                    }
                    v1 = tva[0];
                    v2 = tva[1];
                    v3 = tva[2];
                    float invw1 = 1.0f / v1.W;
                    float invw2 = 1.0f / v2.W;
                    float invw3 = 1.0f / v3.W;
                    Vector4 tv1 = new Vector4(v1.X * invw1, v1.Y * invw1, v1.Z * invw1, 1.0f * invw1);
                    Vector4 tv2 = new Vector4(v2.X * invw2, v2.Y * invw2, v2.Z * invw2, 1.0f * invw2);
                    Vector4 tv3 = new Vector4(v3.X * invw3, v3.Y * invw3, v3.Z * invw3, 1.0f * invw3);
                    if (culling) if (Vector3.Cross(new Vector3(tv2.X - tv1.X, tv1.Y - tv2.Y, 0), new Vector3(tv3.X - tv1.X, tv1.Y - tv3.Y, 0)).Z >= 0) return;
                    Triangle(new Vector4[] { tv1, tv2, tv3 }, tuv, tc);
                }
                else // tvnc = 2
                {
                    {
                        float a1 = tva[tvn[0]].Z / (tva[tvn[0]].Z - tva[tv[0]].Z);
                        float a2 = tva[tvn[1]].Z / (tva[tvn[1]].Z - tva[tv[0]].Z);
                        tva[tv[0]] = Vector4.Lerp(tva[tvn[0]], tva[tv[0]], a1);
                        tuv[tv[0]] = Vector2.Lerp(uv[tvn[0]], uv[tv[0]], a1);
                        if (blendvertex)
                        {
                            tc[tv[0]] = merge(c[tvn[0]], c[tv[0]], a1);
                        }
                        float invw1 = 1.0f / tva[0].W;
                        float invw2 = 1.0f / tva[1].W;
                        float invw3 = 1.0f / tva[2].W;
                        Vector4 tv1 = new Vector4(tva[0].X * invw1, tva[0].Y * invw1, tva[0].Z * invw1, 1.0f * invw1);
                        Vector4 tv2 = new Vector4(tva[1].X * invw2, tva[1].Y * invw2, tva[1].Z * invw2, 1.0f * invw2);
                        Vector4 tv3 = new Vector4(tva[2].X * invw3, tva[2].Y * invw3, tva[2].Z * invw3, 1.0f * invw3);
                        if (culling)
                            if (!(Vector3.Cross(new Vector3(tv2.X - tv1.X, tv1.Y - tv2.Y, 0), new Vector3(tv3.X - tv1.X, tv1.Y - tv3.Y, 0)).Z >= 0))
                            {
                                Triangle(new Vector4[] { tv1, tv2, tv3 }, tuv, tc);
                            }
                        Vector4[] tvb = new Vector4[] { v1, v2, v3 };
                        tva = new Vector4[] { v1, v2, v3 };
                        tuv = new Vector2[] { uv[0], uv[1], uv[2] };
                        tc = new int[] { c[0], c[1], c[2] };
                        // Make tva[tvn[0]] the left edge.
                        // Leave tva[tvn[1]]
                        // Make tva[tv[0]] the right edge.
                        tva[tvn[0]] = Vector4.Lerp(tvb[tvn[0]], tvb[tv[0]], a1);
                        tva[tv[0]] = Vector4.Lerp(tvb[tvn[1]], tvb[tv[0]], a2);
                        tuv[tvn[0]] = Vector2.Lerp(uv[tvn[0]], uv[tv[0]], a1);
                        tuv[tv[0]] = Vector2.Lerp(uv[tvn[1]], uv[tv[0]], a2);
                        if (blendvertex)
                        {
                            tc[tvn[0]] = merge(c[tvn[0]], c[tv[0]], a1);
                            tc[tv[0]] = merge(c[tvn[1]], c[tv[0]], a2);
                        }
                        invw1 = 1.0f / tva[0].W;
                        invw2 = 1.0f / tva[1].W;
                        invw3 = 1.0f / tva[2].W;
                        tv1 = new Vector4(tva[0].X * invw1, tva[0].Y * invw1, tva[0].Z * invw1, 1.0f * invw1);
                        tv2 = new Vector4(tva[1].X * invw2, tva[1].Y * invw2, tva[1].Z * invw2, 1.0f * invw2);
                        tv3 = new Vector4(tva[2].X * invw3, tva[2].Y * invw3, tva[2].Z * invw3, 1.0f * invw3);
                        if (culling)
                            if (!(Vector3.Cross(new Vector3(tv2.X - tv1.X, tv1.Y - tv2.Y, 0), new Vector3(tv3.X - tv1.X, tv1.Y - tv3.Y, 0)).Z >= 0))
                            {
                                Triangle(new Vector4[] { tv1, tv2, tv3 }, tuv, tc);
                            }
                    }
                }
            }
        }

        private unsafe void Clear(int color, float depth)
        {
            int* ptr = (int*)bd.Scan0.ToPointer();
            int* endptr = ptr + bd.Width * bd.Height;
            while (ptr < endptr)
                *(ptr++) = color;
            for (int i = 0; i < bd.Width*bd.Height; i++)
                this.depth[i] = depth;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            buffer.Dispose();
            g.Dispose();
            buffer = new Bitmap(ClientSize.Width * (int)scale, ClientSize.Height * (int)scale);
            g = Graphics.FromImage(buffer);
            unsafe
            {
                if (depth != (float*)0) System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)depth);
                depth = (float*)System.Runtime.InteropServices.Marshal.AllocHGlobal(buffer.Width * buffer.Height * sizeof(float)); //new float[buffer.Width * buffer.Height];
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mp = e.Location;
        }
    }
}
