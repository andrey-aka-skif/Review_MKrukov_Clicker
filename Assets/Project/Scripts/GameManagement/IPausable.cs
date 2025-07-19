namespace Assets.Project.Scripts.GameManagement
{
    public interface IPausable
    {
        bool IsPaused { get; }
        bool IsPlaying { get; }

        void Play();
        void Pause();
        void Restart();
        void Stop();
    }
}
