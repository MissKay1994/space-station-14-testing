// SPDX-FileCopyrightText: 2025 Contributors of the _CD upstream project
// SPDX-FileCopyrightText: 2025 OnyxTheBrave <vinjeerik@gmail.com>
// SPDX-FileCopyrightText: 2025 ReboundQ3 <ReboundQ3@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Server.Body.Systems;
using Content.Shared.Chat.TypingIndicator;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;

namespace Content.Server._CD.Traits;

public sealed class SynthSystem : EntitySystem
{
    [Dependency] private readonly BloodstreamSystem _bloodstream = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SynthComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<SynthComponent, BeforeShowTypingIndicatorEvent>(OnBeforeShowTypingIndicator);
    }

    private void OnStartup(EntityUid uid, SynthComponent component, ComponentStartup args)
    {
        // Ensure they have a typing indicator component
        EnsureComp<TypingIndicatorComponent>(uid);

        // Give them synth blood. Ion storm notif is handled in that system
        _bloodstream.ChangeBloodReagent(uid, new ProtoId<ReagentPrototype>("SynthBlood"));
    }

    private void OnBeforeShowTypingIndicator(EntityUid uid, SynthComponent component, BeforeShowTypingIndicatorEvent args)
    {
        // Override the typing indicator to use the robot indicator
        args.TryUpdateTimeAndIndicator(component.TypingIndicatorPrototype, null);
    }
}
