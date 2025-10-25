using Content.Shared._SV.EyeTracker;
using Content.Shared.Actions.Events;
using Robust.Client.Graphics;
using JetBrains.Annotations;

namespace Content.Client._SV.EyeTracker;
[Access(typeof(EyeTrackerComponent))]

public sealed class EyeTrackerSystem
{
    [Dependency] private readonly IEyeManager _eyeManager = default!;
    [Dependency] private readonly IEntityManager _entityManager = default!;


    private void EyeTracker(EyeTrackerComponent eyeTracker)
    {
        if (eyeTracker.Rotation != _eyeManager.CurrentEye.Rotation)
            eyeTracker.Rotation = _eyeManager.CurrentEye.Rotation;
        return;
    }
}
