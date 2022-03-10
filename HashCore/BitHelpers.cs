namespace HashCore;

static class BitHelpers
{
    public static int FlipBit(int input, int position)
    {
        return input ^ (1 << position);
    }
}