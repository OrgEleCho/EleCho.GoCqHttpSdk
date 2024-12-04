using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Numerics;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 文本识别
/// </summary>
public record class CqTextDetection
{
    /// <summary>
    /// 文本
    /// </summary>
    public string Text { get; } = string.Empty;

    /// <summary>
    /// 置信度
    /// </summary>
    public int Confidence { get; }

    /// <summary>
    /// 坐标
    /// </summary>
    public Vector2[] Coordinates { get; }

    internal CqTextDetection(CqTextDetectionModel model)
    {
        Text = model.text;
        Confidence = model.confidence;
        Coordinates = model.coordinates;
    }
}