﻿namespace Olm.Service.DTOs.ProgressTrackings;

public class ProgressTrackingResultDto
{
    public long Id { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public long LessonId { get; set; }
}