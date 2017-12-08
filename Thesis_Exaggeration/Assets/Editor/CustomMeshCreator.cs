using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;


/*************************************************************************************************
 * This script is a simplified and edited version of the CreatePlane.cs script available on  the
 * Unity Community Wiki (http://wiki.unity3d.com/index.php?title=CreatePlane). It also 
 * incorporates a tangent calculation function written by noontz on unity forums 
 * (http://forum.unity3d.com/threads/how-to-calculate-mesh-tangents.38984/).
 * 
 * All credit goes to the original authors.
 ************************************************************************************************/


public class CustomMeshCreator : ScriptableWizard
{
	public int columns = 1;
	public int rows = 1;
    public bool CalculateTangents = false;
	
	[MenuItem("RealWater/Create Custom Water Mesh")]
	static void CreateWizard()
	{		
        ScriptableWizard.DisplayWizard("Create Custom Water Mesh", typeof(CreatePlane));
	}
	
	
	void OnWizardCreate()
	{
        if (columns * rows <= 65025)
        {
            Vector2 anchorOffset;            
            anchorOffset = Vector2.zero;

            //Check if directory is present
            if (!Directory.Exists("Assets/RealWater/Custom Meshes/"))
            {
                //If not, create it
                Directory.CreateDirectory("Assets/RealWater/Custom Meshes/");

            }

            string planeAssetName = columns + "x" + rows  + "(" + "CalculateTangents" +"=" + CalculateTangents.ToString() + ")" +".asset";
            Mesh m = (Mesh)AssetDatabase.LoadAssetAtPath("Assets/RealWater/Custom Meshes/" + planeAssetName, typeof(Mesh));

            if (m == null)
            {
                m = new Mesh();
                m.name = planeAssetName;

                int hCount2 = columns + 1;
                int vCount2 = rows + 1;
                int numTriangles = columns * rows * 6;
                
                int numVertices = hCount2 * vCount2;

                Vector3[] vertices = new Vector3[numVertices];
                Vector2[] uvs = new Vector2[numVertices];
                int[] triangles = new int[numTriangles];

                int index = 0;
                float uvFactorX = 1.0f / columns;
                float uvFactorY = 1.0f / rows;
                float scaleX = 1f / columns;
                float scaleY = 1f / rows;
                for (float y = 0.0f; y < vCount2; y++)
                {
                    for (float x = 0.0f; x < hCount2; x++)
                    {
                        
                        vertices[index] = new Vector3(x * scaleX - 1f / 2f - anchorOffset.x, 0.0f, y * scaleY - 1f / 2f - anchorOffset.y);
                      
                        uvs[index++] = new Vector2(x * uvFactorX, y * uvFactorY);
                    }
                }

                index = 0;
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        triangles[index] = (y * hCount2) + x;
                        triangles[index + 1] = ((y + 1) * hCount2) + x;
                        triangles[index + 2] = (y * hCount2) + x + 1;

                        triangles[index + 3] = ((y + 1) * hCount2) + x;
                        triangles[index + 4] = ((y + 1) * hCount2) + x + 1;
                        triangles[index + 5] = (y * hCount2) + x + 1;
                        index += 6;
                    }                    
                }

                m.vertices = vertices;
                m.uv = uvs;
                m.triangles = triangles;
                m.RecalculateNormals();

                AssetDatabase.CreateAsset(m, "Assets/RealWater/Custom Meshes/" + planeAssetName);
                AssetDatabase.SaveAssets();
            }
            m.RecalculateBounds();

            if (CalculateTangents) TangentSolver(m);
        }
        else Debug.LogError("Number of Verticies exceeds 65025, please reduce the number of width/length segments. (#Verts = (Width Segs +1)*(Length Segs +1))");       
	}

    /******************************************************************************************************************************************
	* private static void TangentSolver(Mesh theMesh)
	* 
	* SUMMARY: Tangent solver, by noontz on unity forums (http://forum.unity3d.com/threads/how-to-calculate-mesh-tangents.38984/).
	* 		  (Derived from Lengyel, Eric. "Computing Tangent Space Basis Vectors for an Arbitrary Mesh". Terathon Software 3D Graphics Library, 2001.
	*		  (http://www.terathon.com/code/tangent.html)
	*******************************************************************************************************************************************/	
    private static void TangentSolver(Mesh theMesh)
    {
        int vertexCount = theMesh.vertexCount;
        Vector3[] Vertices = theMesh.vertices;
        Vector3[] normals = theMesh.normals;
        Vector2[] texcoords = theMesh.uv;
        int[] triangles = theMesh.triangles;
        int triangleCount = triangles.Length / 3;

        Vector4[] tangents = new Vector4[vertexCount];
        Vector3[] tan1 = new Vector3[vertexCount];
        Vector3[] tan2 = new Vector3[vertexCount];

        int tri = 0;

        for (int i = 0; i < (triangleCount); i++)
        {
            int i1 = triangles[tri];
            int i2 = triangles[tri + 1];
            int i3 = triangles[tri + 2];

            Vector3 v1 = Vertices[i1];
            Vector3 v2 = Vertices[i2];
            Vector3 v3 = Vertices[i3];

            Vector2 w1 = texcoords[i1];
            Vector2 w2 = texcoords[i2];
            Vector2 w3 = texcoords[i3];

            float x1 = v2.x - v1.x;
            float x2 = v3.x - v1.x;
            float y1 = v2.y - v1.y;
            float y2 = v3.y - v1.y;
            float z1 = v2.z - v1.z;
            float z2 = v3.z - v1.z;

            float s1 = w2.x - w1.x;
            float s2 = w3.x - w1.x;
            float t1 = w2.y - w1.y;
            float t2 = w3.y - w1.y;

            float r = 1.0f / (s1 * t2 - s2 * t1);
            Vector3 sdir = new Vector3((t2 * x1 - t1 * x2) * r, (t2 * y1 - t1 * y2) * r, (t2 * z1 - t1 * z2) * r);
            Vector3 tdir = new Vector3((s1 * x2 - s2 * x1) * r, (s1 * y2 - s2 * y1) * r, (s1 * z2 - s2 * z1) * r);

            tan1[i1] += sdir;
            tan1[i2] += sdir;
            tan1[i3] += sdir;

            tan2[i1] += tdir;
            tan2[i2] += tdir;
            tan2[i3] += tdir;

            tri += 3;

        }

        for (int i = 0; i < (vertexCount); i++)
        {

            Vector3 n = normals[i];
            Vector3 t = tan1[i];

            // Gram-Schmidt orthogonalize
            Vector3.OrthoNormalize(ref n, ref t);

            tangents[i].x = t.x;
            tangents[i].y = t.y;
            tangents[i].z = t.z;

            // Calculate handedness
            tangents[i].w = (Vector3.Dot(Vector3.Cross(n, t), tan2[i]) < 0.0f) ? -1.0f : 1.0f;

        }
        theMesh.tangents = tangents;
    }
}
