namespace NvAPIWrapper.Native.Interfaces.GPU
{
    public interface IClockFrequencies
    {
        IGpuClock[] GpuClocks { get; }
        IGpuClock GraphicsClock { get; }
        IGpuClock MemoryClock { get; }
        IGpuClock ProcessorClock { get; }
        IGpuClock VideoClock { get; }
    }
}