using System;

namespace Math3D
{
    public struct Matrix
	{
		public float M11, M12, M13, M14,
			  M21, M22, M23, M24,
			  M31, M32, M33, M34,
			  M41, M42, M43, M44;
		public Matrix (float _11, float _12, float _13, float _14, 
				float _21, float _22, float _23, float _24, 
				float _31, float _32, float _33, float _34, 
				float _41, float _42, float _43, float _44
				)
		{
			M11 = _11; M12 = _12; M13 = _13; M14 = _14;
			M21 = _21; M22 = _22; M23 = _23; M24 = _24;
			M31 = _31; M32 = _32; M33 = _33; M34 = _34;
			M41 = _41; M42 = _42; M43 = _43; M44 = _44;
		}
		public float this[int x, int y]
		{
			get
			{
				switch (x)
				{
				case 1:
					switch (y)
					{
					case 1:
						return M11;
					case 2:
						return M12;
					case 3:
						return M13;
					case 4:
						return M14;
					}
					break;
				case 2:
					switch (y)
					{
					case 1:
						return M21;
					case 2:
						return M22;
					case 3:
						return M23;
					case 4:
						return M24;
					}
					break;
				case 3:
					switch (y)
					{
					case 1:
						return M31;
					case 2:
						return M32;
					case 3:
						return M33;
					case 4:
						return M34;
					}
					break;
				case 4:
					switch (y)
					{
					case 1:
						return M41;
					case 2:
						return M42;
					case 3:
						return M43;
					case 4:
						return M44;
					}
					break;
				}
				throw new System.ArgumentOutOfRangeException();
			}
			set
			{
				switch (x)
				{
				case 1:
					switch (y)
					{
					case 1:
						M11 = value;
						return;
					case 2:
						M12 = value;
						return;
					case 3:
						M13 = value;
						return;
					case 4:
						M14 = value;
						return;
					}
					break;
				case 2:
					switch (y)
					{
					case 1:
						M21 = value;
						return;
					case 2:
						M22 = value;
						return;
					case 3:
						M23 = value;
						return;
					case 4:
						M24 = value;
						return;
					}
					break;
				case 3:
					switch (y)
					{
					case 1:
						M31 = value;
						return;
					case 2:
						M32 = value;
						return;
					case 3:
						M33 = value;
						return;
					case 4:
						M34 = value;
						return;
					}
					break;
				case 4:
					switch (y)
					{
					case 1:
						M41 = value;
						return;
					case 2:
						M42 = value;
						return;
					case 3:
						M43 = value;
						return;
					case 4:
						M44 = value;
						return;
					}
					break;
				}
				throw new System.ArgumentOutOfRangeException();
			}
		}
		// Helper class for computing matrix inverse
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
		struct Matrix2
		{
		    public float M11, M12, M21, M22;
			public static Matrix2 operator*(Matrix2 l, Matrix2 r)
			{
				Matrix2 ret;
				ret.M11 = l.M11*r.M11+l.M12*r.M21;
				ret.M12 = l.M11*r.M12+l.M12*r.M22;
				ret.M21 = l.M21*r.M11+l.M22*r.M21;
				ret.M22 = l.M21*r.M12+l.M22*r.M22;
				return ret;
			}
			public static Matrix2 operator+(Matrix2 l, Matrix2 r)
			{
				Matrix2 ret;
				ret.M11 = l.M11 + r.M11;
				ret.M12 = l.M12 + r.M12;
				ret.M21 = l.M21 + r.M21;
				ret.M22 = l.M22 + r.M22;
				return ret;
			}
			public static Matrix2 operator-(Matrix2 l, Matrix2 r)
			{
				Matrix2 ret;
				ret.M11 = l.M11 - r.M11;
				ret.M12 = l.M12 - r.M12;
				ret.M21 = l.M21 - r.M21;
				ret.M22 = l.M22 - r.M22;
				return ret;
			}
			public static Matrix2 operator-(Matrix2 m)
			{
				Matrix2 ret;
				ret.M11 = -m.M11;
				ret.M12 = -m.M12;
				ret.M21 = -m.M21;
				ret.M22 = -m.M22;
				return ret;
			}
			public float Determinant { get { return M11*M22-M12*M21; } }
			public Matrix2 Inverse 
			{ 
				get
				{ 
					Matrix2 ret;
					float id = 1.0f/Determinant;
					ret.M11 = M22*id;
					ret.M22 = M11*id;
					ret.M12 = -M12*id;
					ret.M21 = -M21*id;
					return ret;
				}
			}
			public Matrix2(float m11, float m12, float m21, float m22) { M11 = m11; M12 = m12; M21 = m21; M22 = m22; }
		};
        public static Matrix Identity
        {
            get{
		        Matrix m = new Matrix();
		        m.M11 = 1.0f; m.M12 = 0.0f; m.M13 = 0.0f; m.M14 = 0.0f;
		        m.M21 = 0.0f; m.M22 = 1.0f; m.M23 = 0.0f; m.M24 = 0.0f;
		        m.M31 = 0.0f; m.M32 = 0.0f; m.M33 = 1.0f; m.M34 = 0.0f;
		        m.M41 = 0.0f; m.M42 = 0.0f; m.M43 = 0.0f; m.M44 = 1.0f;
		        return m;
            }
	    }
        /*Matrix::Matrix(Microsoft::DirectX::Matrix& m)
	    {
		    M11 = m.M11;
		    M12 = m.M12;
		    M13 = m.M13;
		    M14 = m.M14;
		    M21 = m.M21;
		    M22 = m.M22;
		    M23 = m.M23;
		    M24 = m.M24;
		    M31 = m.M31;
		    M32 = m.M32;
		    M33 = m.M33;
		    M34 = m.M34;
		    M41 = m.M41;
		    M42 = m.M42;
		    M43 = m.M43;
		    M44 = m.M44;
	    }
	    Matrix& Matrix::operator*=(Matrix& m)
	    {
		    Matrix t = Matrix(*this);
		    t = t*m;
		    M11 = t.M11;
		    M12 = t.M12;
		    M13 = t.M13;
		    M14 = t.M14;
		    M21 = t.M21;
		    M22 = t.M22;
		    M23 = t.M23;
		    M24 = t.M24;
		    M31 = t.M31;
		    M32 = t.M32;
		    M33 = t.M33;
		    M34 = t.M34;
		    M41 = t.M41;
		    M42 = t.M42;
		    M43 = t.M43;
		    M44 = t.M44;
		    return *this;
	    }*/
	    public static Matrix operator*(Matrix m1, Matrix m2)
	    {
		    Matrix m = new Matrix();
		    m.M11 = m1.M11*m2.M11 + m1.M12*m2.M21 + m1.M13*m2.M31 + m1.M14*m2.M41;
		    m.M12 = m1.M11*m2.M12 + m1.M12*m2.M22 + m1.M13*m2.M32 + m1.M14*m2.M42;
		    m.M13 = m1.M11*m2.M13 + m1.M12*m2.M23 + m1.M13*m2.M33 + m1.M14*m2.M43;
		    m.M14 = m1.M11*m2.M14 + m1.M12*m2.M24 + m1.M13*m2.M34 + m1.M14*m2.M44;

		    m.M21 = m1.M21*m2.M11 + m1.M22*m2.M21 + m1.M23*m2.M31 + m1.M24*m2.M41;
		    m.M22 = m1.M21*m2.M12 + m1.M22*m2.M22 + m1.M23*m2.M32 + m1.M24*m2.M42;
		    m.M23 = m1.M21*m2.M13 + m1.M22*m2.M23 + m1.M23*m2.M33 + m1.M24*m2.M43;
		    m.M24 = m1.M21*m2.M14 + m1.M22*m2.M24 + m1.M23*m2.M34 + m1.M24*m2.M44;

		    m.M31 = m1.M31*m2.M11 + m1.M32*m2.M21 + m1.M33*m2.M31 + m1.M34*m2.M41;
		    m.M32 = m1.M31*m2.M12 + m1.M32*m2.M22 + m1.M33*m2.M32 + m1.M34*m2.M42;
		    m.M33 = m1.M31*m2.M13 + m1.M32*m2.M23 + m1.M33*m2.M33 + m1.M34*m2.M43;
		    m.M34 = m1.M31*m2.M14 + m1.M32*m2.M24 + m1.M33*m2.M34 + m1.M34*m2.M44;

		    m.M41 = m1.M41*m2.M11 + m1.M42*m2.M21 + m1.M43*m2.M31 + m1.M44*m2.M41;
		    m.M42 = m1.M41*m2.M12 + m1.M42*m2.M22 + m1.M43*m2.M32 + m1.M44*m2.M42;
		    m.M43 = m1.M41*m2.M13 + m1.M42*m2.M23 + m1.M43*m2.M33 + m1.M44*m2.M43;
		    m.M44 = m1.M41*m2.M14 + m1.M42*m2.M24 + m1.M43*m2.M34 + m1.M44*m2.M44;
		    return m;
	    }
        public static Matrix Translation(float x, float y, float z)
	    {
		    Matrix m = Identity;
		    m.M41 = x;
		    m.M42 = y;
		    m.M43 = z;
		    return m;
	    }
	    public static Matrix Translation(Vector3 v)
	    {
		    Matrix m = Identity;
		    m.M41 = v.X;
		    m.M42 = v.Y;
		    m.M43 = v.Z;
		    return m;
	    }
	    public static Matrix Scaling(float x, float y, float z)
	    {
		    Matrix m = Identity;
		    m.M11 = x;
		    m.M22 = y;
		    m.M33 = z;
		    return m;
	    }
	    public static Matrix Scaling(Vector3 v)
	    {
		    Matrix m = Identity;
		    m.M11 = v.X;
		    m.M22 = v.Y;
		    m.M33 = v.Z;
		    return m;
	    }
	    public static Matrix RotationAxis(float x, float y, float z, float angle)
	    {
		    return RotationAxis(new Vector3(x, y, z), angle);
	    }
	    public static Matrix RotationAxis(Vector3 axis, float angle)
	    {
		    if (angle == 0.0f || axis.LengthSq() == 0.0f) return Identity;
		    axis.Normalize();
		    float anglez = 0.0f;
		    float l = axis.X*axis.X+axis.Y*axis.Y;
		    if (l != 0.0f)
		    {
			    l = (float)Math.Sqrt(l);
			    anglez = (float)Math.Acos(axis.X/l)*(axis.Y > 0.0f ? 1.0f : -1.0f);
			    axis.TransformCoordinate(RotationZ(-anglez));
		    }
		    float angley = (float)Math.Acos(axis.X)*(axis.Z < 0.0f ? 1.0f : -1.0f);
		    return RotationZ(-anglez)*RotationY(-angley)*RotationX(angle)*RotationY(angley)*RotationZ(anglez);
	    }
	    public static Matrix Invert(Matrix m)
	    {
		    Matrix2 A = new Matrix2(m.M11, m.M12, m.M21, m.M22),
				    B = new Matrix2(m.M13, m.M14, m.M23, m.M24),
				    C = new Matrix2(m.M31, m.M32, m.M41, m.M42),
				    D = new Matrix2(m.M33, m.M34, m.M43, m.M44);
		    Matrix2 ai = A.Inverse, sc = (D - C * ai * B).Inverse;
		    Matrix2 a = ai+ai*B*sc*C*ai,	b = -ai*B*sc, c = -sc*C*ai,	d = sc;
		    return new Matrix(a.M11, a.M12, b.M11, b.M12, a.M21, a.M22, b.M21, b.M22, c.M11, c.M12, d.M11, d.M12, c.M21, c.M22, d.M21, d.M22);
	    }
	    /*Matrix Matrix::RotationQuaternion(Quaternion q)
	    {
		    if (q.W == 1) return Matrix::Identity;
		    float angle = acosf(q.W)*2;
		    float s = 1.0f/sinf(angle*0.5f);
		    return Matrix::RotationAxis(q.X*s, q.Y*s, q.Z*s, angle);
	    }*/
        /* Construct rotation matrix from (possibly non-unit) quaternion.
        * Assumes matrix is used to multiply column vector on the left:
        * vnew = mat vold. Works correctly for right-handed coordinate system
        * and right-handed rotations. */
        public static Matrix RotationQuaternion(Quaternion q)
        {
	        q = Quaternion.Conjugate(q);
	        float Nq = q.X*q.X+q.Y*q.Y+q.Z*q.Z+q.W*q.W;
	        float s = Nq > 0.0f ? 2.0f/Nq : 0.0f;
	        float xs = q.X*s, ys = q.Y*s, zs = q.Z*s;
	        float wx = q.W*xs, wy = q.W*ys, wz = q.W*zs;
	        float xx = q.X*xs, xy = q.X*ys, xz = q.X*zs;
	        float yy = q.Y*ys, yz = q.Y*zs, zz = q.Z*zs;
	        Matrix m;
	        m.M11 = 1.0f - (yy + zz); m.M21 = xy + wz; m.M31 = xz - wy;
	        m.M12 = xy - wz; m.M22 = 1.0f - (xx + zz); m.M32 = yz + wx;
	        m.M13 = xz + wy; m.M23 = yz - wx; m.M33 = 1.0f - (xx + yy);
	        m.M14 = m.M24 = m.M34 = 0.0f;
	        m.M41 = m.M42 = m.M43 = 0.0f;
	        m.M44 = 1.0f;
	        return m;
        }
        public static Matrix RotationX(float angle)
        {
	        Matrix m = Identity;
	        float c = (float)Math.Cos(angle);
	        float s = (float)Math.Sin(angle);
	        m.M22 = c;
	        m.M23 = s;
	        m.M32 = -s;
	        m.M33 = c;
	        return m;
        }
        public static Matrix RotationY(float angle)
        {
	        Matrix m = Identity;
	        float c = (float)Math.Cos(angle);
	        float s = (float)Math.Sin(angle);
	        m.M11 = c;
	        m.M13 = -s;
	        m.M31 = s;
	        m.M33 = c;
	        return m;
        }
        public static Matrix RotationZ(float angle)
        {
	        Matrix m = Identity;
	        float c = (float)Math.Cos(angle);
	        float s = (float)Math.Sin(angle);
	        m.M11 = c;
	        m.M12 = s;
	        m.M21 = -s;
	        m.M22 = c;
	        return m;
        }
        public static Matrix LookAtLH(Vector3 eye, Vector3 to, Vector3 up)
        {
	        Vector3 zaxis = Vector3.Normalize(to-eye);
	        Vector3 xaxis = Vector3.Normalize(Vector3.Cross(up, zaxis));
	        Vector3 yaxis = Vector3.Cross(zaxis, xaxis);
	        Matrix m = Matrix.Identity;
	        m.M11 = xaxis.X; m.M12 = yaxis.X; m.M13 = zaxis.X;
	        m.M21 = xaxis.Y; m.M22 = yaxis.Y; m.M23 = zaxis.Y;
	        m.M31 = xaxis.Z; m.M32 = yaxis.Z; m.M33 = zaxis.Z;
	        m.M41 = -Vector3.Dot(xaxis, eye);
	        m.M42 = -Vector3.Dot(yaxis, eye);
	        m.M43 = -Vector3.Dot(zaxis, eye);
	        return m;
        }
        public static Matrix PerspectiveFovLH(float angle, float aspect, float znear, float zfar)
        {
	        float yscale = 1.0f/(float)Math.Tan(angle*0.5f);
	        float xscale = yscale/aspect;
	        Matrix m = new Matrix();
	        m.M11 = xscale;
	        m.M22 = yscale;
	        m.M33 = zfar/(zfar-znear);
	        m.M43 = -znear*zfar/(zfar-znear);
	        m.M34 = 1.0f;
	        return m;
        }
        public static Matrix OrthoLH(float width, float height, float znear, float zfar)
        {
            Matrix m = new Matrix();
            m.M11 = 2.0f/width;
            m.M22 = 2.0f/height;
            m.M33 = 1.0f / (zfar - znear);
            m.M43 = -znear / (zfar - znear);
            m.M44 = 1.0f;
            return m;
        }
        public static Matrix Transpose(Matrix m)
	    {
		    Matrix t;
		    t.M11 = m.M11; t.M12 = m.M21; t.M13 = m.M31; t.M14 = m.M41;
		    t.M21 = m.M12; t.M22 = m.M22; t.M23 = m.M32; t.M24 = m.M42;
		    t.M31 = m.M13; t.M32 = m.M23; t.M33 = m.M33; t.M34 = m.M43;
		    t.M41 = m.M14; t.M42 = m.M24; t.M43 = m.M34; t.M44 = m.M44;
		    return t;
	    }
	    public override string ToString()
	    {
		    System.Text.StringBuilder sb = new System.Text.StringBuilder();
		    sb.AppendFormat("M11: {0}\n", M11);
		    sb.AppendFormat("M12: {0}\n", M12);
		    sb.AppendFormat("M13: {0}\n", M13);
		    sb.AppendFormat("M14: {0}\n", M14);
		    sb.AppendFormat("M21: {0}\n", M21);
		    sb.AppendFormat("M22: {0}\n", M22);
		    sb.AppendFormat("M23: {0}\n", M23);
		    sb.AppendFormat("M24: {0}\n", M24);
		    sb.AppendFormat("M31: {0}\n", M31);
		    sb.AppendFormat("M32: {0}\n", M32);
		    sb.AppendFormat("M33: {0}\n", M33);
		    sb.AppendFormat("M34: {0}\n", M34);
		    sb.AppendFormat("M41: {0}\n", M41);
		    sb.AppendFormat("M42: {0}\n", M42);
		    sb.AppendFormat("M43: {0}\n", M43);
		    sb.AppendFormat("M44: {0}\n", M44);
		    return sb.ToString();
	    }
	}

	public struct Vector2
	{
		public float X, Y;
		public static Vector2 Empty { get{ return new Vector2(0, 0); } }
    	public Vector2(float x, float y)
	    {
		    X = x;
		    Y = y;
	    }
		public override string ToString()
	    {
		    return string.Format("X: {0}\r\nY: {1}\r\n", X, Y);
	    }
        public static float Dot(Vector2 left, Vector2 right)
	    {
		    return left.X*right.X+left.Y*right.Y;
	    }
	    public float Length()
	    {
		    return (float)Math.Sqrt(X*X+Y*Y);
	    }
	    public float LengthSq()
	    {
		    return X*X+Y*Y;
	    }
	    public void Normalize()
	    {
		    float l = (float)Math.Sqrt(X*X+Y*Y);
		    X /= l;
		    Y /= l;
	    }
        public static Vector2 Lerp(Vector2 left, Vector2 right, float interpolater)
        {
            //return left + (right-left)*interpolater;
            return new Vector2(
                left.X + interpolater * (right.X - left.X),
                left.Y + interpolater * (right.Y - left.Y));
        }
        public static Vector2 Scale(Vector2 v, float s)
        {
            return new Vector2(v.X * s, v.Y * s);
        }
	}

	public struct Vector3
	{
		public float X, Y, Z;
		public Vector3(float x, float y, float z)
	    {
		    X = x;
		    Y = y;
		    Z = z;
	    }
		public static Vector3 Empty { get{ return new Vector3(0, 0, 0); } }
		public void Lerp(Vector3 right, float interpolater)
		{
			// *this += (right-*this)*interpolater;
			X += (right.X-X)*interpolater;
			Y += (right.Y-Y)*interpolater;
			Z += (right.Z-Z)*interpolater;
		}
		public static Vector3 operator *(Vector3 v, float s) { return new Vector3(v.X*s, v.Y*s, v.Z*s); }
		public static Vector3 operator /(Vector3 v, float d) { return new Vector3(v.X/d, v.Y/d, v.Z/d); }
        public static Vector3 operator /(Vector3 v1, Vector3 v2) { return new Vector3(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z); }
		public static Vector3 operator +(Vector3 v1, Vector3 v2) { return new Vector3(v1.X+v2.X, v1.Y+v2.Y, v1.Z + v2.Z); }
		public override string ToString()
	    {
		    return string.Format("X: {0}\r\nY: {1}\r\nZ: {2}\r\n", X, Y, Z);
	    }
    	public static float Dot(Vector3 left, Vector3 right)
	    {
		    return left.X*right.X+left.Y*right.Y+left.Z*right.Z;
	    }
	    public static Vector3 Normalize(Vector3 left)
	    {
		    left.Normalize();
		    return left;
	    }
        public static Vector3 Scale(Vector3 v, float s)
        {
            return new Vector3(v.X * s, v.Y * s, v.Z * s);
        }
        public static Vector3 Scale(Vector3 v, float sx, float sy, float sz)
        {
            return new Vector3(v.X * sx, v.Y * sy, v.Z * sz);
        }
	    public float Length()
	    {
		    return (float)Math.Sqrt(X*X+Y*Y+Z*Z);
	    }
	    public float LengthSq()
	    {
		    return X*X+Y*Y+Z*Z;
	    }
	    public void Normalize()
	    {
		    float l = (float)Math.Sqrt(X*X+Y*Y+Z*Z);
		    X /= l;
		    Y /= l;
		    Z /= l;
	    }
	    public static Vector3 operator-(Vector3 a, Vector3 b)
	    {
		    return new Vector3(a.X-b.X, a.Y-b.Y, a.Z-b.Z);
	    }
	    public static Vector3 operator-(Vector3 a)
	    {
		    return new Vector3(-a.X, -a.Y, -a.Z);
	    }
	    public static Vector3 Cross(Vector3 left, Vector3 right)
	    {
		    return new Vector3(left.Y*right.Z-left.Z*right.Y,
					       left.Z*right.X-left.X*right.Z,
					       left.X*right.Y-left.Y*right.X);
	    }
	    public static Vector3 Subtract(Vector3 left, Vector3 right)
	    {
		    return new Vector3(left.X-right.X, left.Y-right.Y, left.Z-right.Z);
	    }
	    public void TransformCoordinate(Matrix m)
	    {
		    float tX = X, tY = Y, tZ = Z;
		    X = tX*m.M11+tY*m.M21+tZ*m.M31+m.M41;
		    Y = tX*m.M12+tY*m.M22+tZ*m.M32+m.M42;
		    Z = tX*m.M13+tY*m.M23+tZ*m.M33+m.M43;
	    }
	    public void TransformNormal(Matrix m)
	    {
		    float tX = X, tY = Y, tZ = Z;
		    X = tX*m.M11+tY*m.M21+tZ*m.M31;
		    Y = tX*m.M12+tY*m.M22+tZ*m.M32;
		    Z = tX*m.M13+tY*m.M23+tZ*m.M33;
	    }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
	    public override bool Equals(object obj)
	    {
		    Vector3 v = (Vector3)obj;
		    if (v == null) return false;
		    return v.X == X && v.Y == Y && v.Z == Z;
	    }
	    public static bool operator ==(Vector3 v1, Vector3 v2)
	    {
		    return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
	    }
	    public static bool operator !=(Vector3 v1, Vector3 v2)
	    {
		    return !(v1 == v2);
	    }
        public static Vector3 Lerp(Vector3 left, Vector3 right, float interpolater)
	    {
		    //return left + (right-left)*interpolater;
		    return new Vector3(
			    left.X + interpolater*(right.X-left.X),
			    left.Y + interpolater*(right.Y-left.Y),
			    left.Z + interpolater*(right.Z-left.Z));
	    }
        public static Vector4 TransformCoordinate(Vector3 v, Matrix m)
        {
            return new Vector4(
                v.X * m.M11 + v.Y * m.M21 + v.Z * m.M31 + m.M41,
                v.X * m.M12 + v.Y * m.M22 + v.Z * m.M32 + m.M42,
                v.X * m.M13 + v.Y * m.M23 + v.Z * m.M33 + m.M43,
                v.X * m.M14 + v.Y * m.M24 + v.Z * m.M34 + m.M44);
        }
	    public static Vector3 TransformNormal(Vector3 v, Matrix m)
	    {
		    return new Vector3(
			    v.X*m.M11+v.Y*m.M21+v.Z*m.M31,
			    v.X*m.M12+v.Y*m.M22+v.Z*m.M32,
			    v.X*m.M13+v.Y*m.M23+v.Z*m.M33);
	    }
	}

	public struct Vector4
	{
		public static Vector4 Empty { get { return new Vector4(0,0,0,0); } }
	    public Vector4(float x, float y, float z, float w)
	    {
		    X = x;
		    Y = y;
		    Z = z;
		    W = w;
	    }
		public float X, Y, Z, W;
	    public override string ToString()
	    {
		    return string.Format("X: {0}\r\nY: {1}\r\nZ: {2}\r\nW: {3}\r\n", X, Y, Z, W);
	    }
        public static Vector4 Lerp(Vector4 left, Vector4 right, float interpolater)
        {
            //return left + (right-left)*interpolater;
            return new Vector4(
                left.X + interpolater * (right.X - left.X),
                left.Y + interpolater * (right.Y - left.Y),
                left.Z + interpolater * (right.Z - left.Z),
                left.W + interpolater * (right.W - left.W));
        }
	}

#region Quaternion
	public struct Quaternion
	{
		const float epsilon = 1.0e-3f;
		public static Quaternion Empty { get { return new Quaternion(0, 0, 0, 0); } }
		public static Quaternion Identity { get { return new Quaternion(0, 0, 0, 1); } }
		public Quaternion(float x, float y, float z, float w)
	    {
		    this.x = x;
		    Y = y;
		    Z = z;
		    W = w;
	    }
		public float x, Y, Z, W;
        /* Return quaternion product qL * qR. */
	    public static Quaternion operator *(Quaternion qL, Quaternion qR)
	    {
		    Quaternion qq = new Quaternion();
		    // qq' = [v x v' + wv' + w'v, ww' - v.v']
		    qq.W = qR.W*qL.W - qR.X*qL.X - qR.Y*qL.Y - qR.Z*qL.Z;
		    qq.X = qR.W*qL.X + qR.X*qL.W + qR.Y*qL.Z - qR.Z*qL.Y;
		    qq.Y = qR.W*qL.Y + qR.Y*qL.W + qR.Z*qL.X - qR.X*qL.Z;
		    qq.Z = qR.W*qL.Z + qR.Z*qL.W + qR.X*qL.Y - qR.Y*qL.X;
		    return qq;
	    }
	    public static Quaternion RotationAxis(Vector3 axis, float angle)
	    {
		    Quaternion q = new Quaternion();
		    axis.Normalize();
		    float sa = (float)Math.Sin(angle*0.5f);
		    q.X = axis.X*sa;
		    q.Y = axis.Y*sa;
		    q.Z = axis.Z*sa;
		    q.W = (float)Math.Cos(angle*0.5f);
		    return q;
	    }
	    public override string ToString()
	    {
		    return string.Format("X: {0}\r\nY: {1}\r\nZ: {2}\r\nW: {3}\r\n", X, Y, Z, W);
	    }
		public float X { get {return x;} set {if (float.IsNaN(value)) System.Diagnostics.Debugger.Break(); x = value;}}
		public static Quaternion operator*(float t, Quaternion q) { return new Quaternion(q.X*t, q.Y*t, q.Z*t, q.W*t); }
		public static Quaternion operator*(Quaternion q, float t) { return new Quaternion(q.X*t, q.Y*t, q.Z*t, q.W*t); }
		public static Quaternion operator/(Quaternion q, float t) { return new Quaternion(q.X/t, q.Y/t, q.Z/t, q.W/t); }
		public static Quaternion operator+(Quaternion l, Quaternion r)
		{
			return new Quaternion(l.X+r.X, l.Y+r.Y, l.Z+r.Z, l.W+r.W);
		}
		public static Quaternion operator-(Quaternion l, Quaternion r)
		{
			return new Quaternion(l.X-r.X, l.Y-r.Y, l.Z-r.Z, l.W-r.W);
		}
		public static Quaternion operator-(Quaternion q)
		{
			return new Quaternion(-q.X, -q.Y, -q.Z, -q.W);
		}
		public static Quaternion operator/(Quaternion l, Quaternion r)
		{
			return l*Quaternion.Invert(r);
		}
		public float LengthSq() { return X*X+Y*Y+Z*Z+W*W; }
		public float Length() { return (float)Math.Sqrt(X*X+Y*Y+Z*Z+W*W); }
		public static Quaternion Conjugate(Quaternion q)
		{
			return new Quaternion(-q.X, -q.Y, -q.Z, q.W);
		}
		public static Quaternion Invert(Quaternion q)
		{
			float ni = 1.0f/q.LengthSq();
			return new Quaternion(-q.X*ni, -q.Y*ni, -q.Z*ni, q.W*ni);
		}
		public static float Dot(Quaternion q1, Quaternion q2)
		{
			return q1.X*q2.X+q1.Y*q2.Y+q1.Z*q2.Z+q1.W*q2.W;
		}
		public static Quaternion Slerp(Quaternion q0, Quaternion q1, float t)
		{
			float cosa = Dot(q0, q1);
			cosa = cosa < -1.0f ? -1.0f : cosa > 1.0f ? 1.0f : cosa;
			/*if (cosa < 0.0f)
			{
				cosa = -cosa;
				q1 = -q1;
			}*/
			float a = (float)Math.Acos(cosa), s = (float)Math.Sin(a);
			if (s <= epsilon) return q0;
			float si = 1.0f/s;
			return q0*si*(float)Math.Sin(a*(1.0f-t))+q1*si*(float)Math.Sin(a*t);
		}
		public static Quaternion Squad(Quaternion q, Quaternion a, Quaternion b, Quaternion c, float t)
		{
			return Slerp(Slerp(q, c, t), Slerp(a, b, t), 2*t*(1.0f-t));
		}
		public static Quaternion Exp(Quaternion q)
		{
			float theta = (float)Math.Sqrt(q.X*q.X+q.Y*q.Y+q.Z*q.Z);
			Quaternion ret = q;
			float st = (float)Math.Sin(theta)/theta;
			if (theta > epsilon)
				ret *= st;
			ret.W = (float)Math.Cos(theta);
			return ret;
		}
		public static Quaternion Ln(Quaternion q)
		{
			float theta = (float)Math.Acos(q.W);
			Quaternion ret = q;
			float st = (float)Math.Sin(theta);
			float inv = 1.0f/st;
			if (st > epsilon)
				ret *= inv*theta;
			ret.W = 0.0f;
			return ret;
		}
		public static Quaternion Normalize(Quaternion q)
		{
			return q/q.LengthSq();
		}
		public static void SquadSetup(out Quaternion AOut, out Quaternion BOut, out Quaternion COut, Quaternion Q0, Quaternion Q1, Quaternion Q2, Quaternion Q3)
		{
			Quaternion q0 = (Q0+Q1).LengthSq() < (Q0-Q1).LengthSq() ? -Q0 : Q0;
			Quaternion q1 = Q1;
			Quaternion q2 = (Q1+Q2).LengthSq() < (Q1-Q2).LengthSq() ? -Q2 : Q2;
			Quaternion q3 = (Q2+Q3).LengthSq() < (Q2-Q3).LengthSq() ? -Q3 : Q3;
			AOut = q1 * Exp(-0.25f*(Ln(Invert(q1)*q2)+Ln(Invert(q1)*q0)));
			BOut = q2 * Exp(-0.25f*(Ln(Invert(q2)*q3)+Ln(Invert(q2)*q1)));
			COut = q2;
		}
		public static Quaternion RotationMatrix(Matrix m)
		{
			Quaternion q = new Quaternion();
			float tr, s;
			tr = m.M11+m.M22+m.M33;
			if (tr >= 0.0f)
			{
				s = (float)Math.Sqrt(tr + m.M44);
				q.W = s*0.5f;
				s = 0.5f / s;
				q.X = (m.M32-m.M23)*s;
				q.Y = (m.M13-m.M31)*s;
				q.Z = (m.M21-m.M12)*s;
			}
			else
			{
				int h = 1;
				if (m.M22 > m.M11) h = 2;
				if (m.M33 > m[h,h]) h = 3;
				switch (h)
				{
//#define caseMacro(i,j,k,I,J,K) \
//					case I: \
//						s = sqrtf(m[I,I]-m[J,J]-m[K,K]+m.M44); \
//						q.i = s*0.5f; \
//						s = 0.5f / s; \
//						q.j = (m[I,J] + m[J,I]) * s;\
//						q.k = (m[K,I] + m[I,K]) * s;\
//						q.W = (m[K,J] - m[J,K]) * s;\
//						break
                    case 1:
                        s = (float)Math.Sqrt(m[1,1]-m[2,2]-m[3,3]+m.M44);
                        q.X = s*0.5f;
                        s = 0.5f / s;
                        q.Y = (m[1,2] + m[2,1]) * s;
                        q.Z = (m[3,1] + m[1,3]) * s;
                        q.W = (m[3,2] - m[2,3]) * s;
                        break;
                    case 2:
                        s = (float)Math.Sqrt(m[2, 2] - m[3, 3] - m[1, 1] + m.M44);
                        q.Y = s*0.5f;
                        s = 0.5f / s;
                        q.Z = (m[2,3] + m[3,2]) * s;
                        q.X = (m[1,2] + m[2,1]) * s;
                        q.W = (m[1,3] - m[3,1]) * s;
                        break;
                    case 3:
                        s = (float)Math.Sqrt(m[3, 3] - m[1, 1] - m[2, 2] + m.M44);
                        q.Z = s*0.5f;
                        s = 0.5f / s;
                        q.X = (m[3,1] + m[1,3]) * s;
                        q.Y = (m[2,3] + m[3,2]) * s;
                        q.W = (m[2,1] - m[1,2]) * s;
                        break;
					//caseMacro(X,Y,Z,1,2,3);
					//caseMacro(Y,Z,X,2,3,1);
					//caseMacro(Z,X,Y,3,1,2);
//#undef caseMacro
				}
			}
			if (m.M44 != 1.0f)
				q *= 1.0f/(float)Math.Sqrt(m.M44);
			return Quaternion.Conjugate(q);
		}
	}
#endregion

}