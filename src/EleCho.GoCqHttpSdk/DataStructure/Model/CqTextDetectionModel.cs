using System.Numerics;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    internal record class CqTextDetectionModel
    {
        [JsonConstructor]
        public CqTextDetectionModel(string text, int confidence, Vector2[] coordinates)
        {
            this.text = text;
            this.confidence = confidence;
            this.coordinates = coordinates;
        }

        public string text { get; set; }
        public int confidence { get; set; }
        public Vector2[] coordinates { get; set; }
    }
}