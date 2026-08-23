namespace PixelFit.Models.Training
{
    public class EditableExerciseSet
    {
        public int Id { get; set; }

        public int Reps { get; set; }

        public double Weight { get; set; }

        public int RestBetweenSets { get; set; }
    }
}