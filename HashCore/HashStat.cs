using System.Numerics;


namespace HashCore;

public class HashStat
{
    private float? _avalancheEffect;
    private readonly Function<int> _func;
    public float AvalancheEffect => _avalancheEffect ??= CalculateAvalancheEffect();
    public Function<int> Function => _func;
        
    public HashStat(Function<int> func)
    {
        _func = func;
    }

    private float CalculateAvalancheEffect()
    {
        var value = new Random().Next();

        var avalanche = new float[32];

        for (int i = 0; i < 32; i++)
        {
            var h0 = _func.Invoke(value);
            value = BitHelpers.FlipBit(value, i);
            var h1 = _func.Invoke(value);
            var distance = HammingDistance(h0, h1);
            avalanche[i] = distance / 32.0f;
        }

        return avalanche.Average();
    }
    private int HammingDistance(int a, int b)
    {
        int difference = a ^ b;
        return BitOperations.PopCount((uint)difference);
    }


}