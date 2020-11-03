namespace SweepstakesManager
{
    /// <summary>
    /// Dependency injection of the Sweepstakes
    /// </summary>
    public interface ISweepstakesManager
    {
        void InsertSweepstakes(Sweepstakes sweepstakes);

        Sweepstakes GetSweepstakes();

    }
}
