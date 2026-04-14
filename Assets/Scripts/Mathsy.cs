using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Mathsy
{
    //Add.
    public static Vector2 Add(Vector2 A, Vector2 B)
    {
        float NewX = A.x + B.x;
        float NewY = A.y + B.y;
        Vector2 Sum = new Vector2(NewX, NewY);
        return Sum;
    }
    
    public static Vector3 Add(Vector3 A, Vector3 B)
    {
        float NewX = A.x + B.x;
        float NewY = A.y + B.y;
        float NewZ = A.z + B.z;
        Vector3 Sum = new Vector3(NewX, NewY, NewZ);
        return Sum;
    }
    //.

    //Subtract.
    public static Vector2 Subtract(Vector2 A, Vector2 B)
    {
        float NewX = A.x - B.x;
        float NewY = A.y - B.y;
        Vector2 Difference = new Vector2(NewX, NewY);
        return Difference;
    }

    public static Vector3 Subtract(Vector3 A, Vector3 B)
    {
        float NewX = A.x - B.x;
        float NewY = A.y - B.y;
        float NewZ = A.z - B.z;
        Vector3 Difference = new Vector3(NewX, NewY, NewZ);
        return Difference;
    }
    //.

    //Scale.
    public static Vector2 Scale(Vector2 Vector, float Scalar)
    {
        float NewX = Vector.x * Scalar;
        float NewY = Vector.y * Scalar;
        Vector2 Scaled = new Vector2(NewX, NewY);
        return Scaled;
    }

    public static Vector3 Scale(Vector3 Vector, float Scalar)
    {
        float NewX = Vector.x * Scalar;
        float NewY = Vector.y * Scalar;
        float NewZ = Vector.z * Scalar;
        Vector3 Scaled = new Vector3(NewX, NewY, NewZ);
        return Scaled;
    }
    //.

    //Magnitude.
    public static float Magnitude(Vector2 Vector)
    {
        float XSquare = Vector.x * Vector.x;
        float YSquare = Vector.y * Vector.y;
        float SquareSum = XSquare + YSquare;
        float Magnitude = Mathf.Sqrt(SquareSum);
        return Magnitude;
    }

    public static float Magnitude(Vector3 Vector)
    {
        float XSquare = Vector.x * Vector.x;
        float YSquare = Vector.y * Vector.y;
        float ZSquare = Vector.z * Vector.z;
        float SquareSum = XSquare + YSquare + ZSquare;
        float Magnitude = Mathf.Sqrt(SquareSum);
        return Magnitude;
    }
    //.

    //Distance.
    public static float Distance(Vector2 A, Vector2 B)
    {
        Vector2 Difference = Subtract(A, B);
        float Distance = Magnitude(Difference);
        return Distance;
    }

    public static float Distance(Vector3 A, Vector3 B)
    {
        Vector3 Difference = Subtract(A, B);
        float Distance = Magnitude(Difference);
        return Distance;
    }
    //.

    //Normalise.
    public static Vector2 Normalise(Vector2 Vector)
    {
        float VectorMagnitude = Magnitude(Vector);
        Vector2 Normalised = Scale(Vector, 1 / VectorMagnitude);
        return Normalised;
    }

    public static Vector3 Normalise(Vector3 Vector)
    {
        float VectorMagnitude = Magnitude(Vector);
        Vector3 Normalised = Scale(Vector, 1 / VectorMagnitude);
        return Normalised;
    }
    //.

    //Dot product.
    public static float Dot(Vector2 A, Vector2 B)
    {
        float Dot = (A.x * B.x) + (A.y * B.y);
        return Dot;
    }

    public static float Dot(Vector3 A, Vector3 B)
    {
        float Dot = (A.x * B.x) + (A.y * B.y) + (A.z * B.z);
        return Dot;
    }
    //.

    //Angle unit conversion.
    public static float DegreeToRadian(float Degree)
    {
        float Radian = Degree * (Mathf.PI / 180);
        return Radian;
    }

    public static float RadianToDegree(float Radian)
    {
        float Degree = Radian * (180 / Mathf.PI);
        return Degree;
    }
    //.

    //Vector2 and angle conversion.
    public static float Vector2ToRadian(Vector2 Vector)
    {
        float Radian = Mathf.Atan2(Vector.y, Vector.x);
        return Radian;
    }

    public static Vector2 RadianToVector2(float Radian)
    {
        float NewX = Mathf.Cos(Radian);
        float NewY = Mathf.Sin(Radian);
        Vector2 Vector = new Vector2(NewX, NewY);
        return Vector;
    }
    //.

    //Get forward from rotation.
    public static Vector3 FindForward(float PitchRadian, float YawRadian)
    {
        float NewX = Mathf.Cos(PitchRadian) * Mathf.Sin(YawRadian);
        float NewY = Mathf.Sin(PitchRadian);
        float NewZ = Mathf.Cos(PitchRadian) * Mathf.Cos(YawRadian);
        Vector3 ForwardVector = new Vector3(NewX, NewY, NewZ);
        return ForwardVector;
    }
    //.

    //Cross product.
    public static Vector3 Cross(Vector3 A, Vector3 B)
    {
        float NewX = (A.y * B.z) - (A.z * B.y);
        float NewY = (A.z * B.x) - (A.x * B.z);
        float NewZ = (A.x * B.y) - (A.y * B.x);
        Vector3 Cross = new Vector3(NewX, NewY, NewZ);
        return Cross;
    }
    //.
}
