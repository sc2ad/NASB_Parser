using NASB_Parser.StateActions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static NASB_Parser.StateActions.StateAction;

namespace JsonDumper.Converters
{
    public class StateActionConverter : JsonConverter<StateAction>
    {
        private static readonly PropertyInfo tidInfo = typeof(StateAction).GetProperty(nameof(StateAction.TID));
        private static readonly PropertyInfo versionInfo = typeof(StateAction).GetProperty(nameof(StateAction.Version));

        public override StateAction ReadJson(JsonReader reader, Type objectType, [AllowNull] StateAction existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, StateAction>(reader, serializer, tidInfo, versionInfo, res => res switch
                {
                    TypeId.DebugId => new SADebugMessage(),
                    TypeId.PlayAnimId => new SAPlayAnim(),
                    TypeId.RootAnimId => new SAPlayRootAnim(),
                    TypeId.SnapAnimWeightsId => new SASnapAnimWeights(),
                    TypeId.StandardInputId => new SAStandardInput(),
                    TypeId.InputId => new SAInputAction(),
                    TypeId.DeactInputId => new SADeactivateInputAction(),
                    TypeId.InputEventFromFrameId => new SAAddInputEventFromFrame(),
                    TypeId.CancelStateId => new SACancelToState(),
                    TypeId.CustomCallId => new SACustomCall(),
                    TypeId.TimerId => new SATimedAction(),
                    TypeId.OrderId => new SAOrderedSensitive(),
                    TypeId.ProxyId => new SAProxyMove(),
                    TypeId.CheckId => new SACheckThing(),
                    TypeId.ActiveActionId => new SAActiveAction(),
                    TypeId.DeactivateActionId => new SADeactivateAction(),
                    TypeId.SetFloatId => new SASetFloatTarget(),
                    TypeId.OnBounceId => new SAOnBounce(),
                    TypeId.OnLeaveEdgeId => new SAOnLeaveEdge(),
                    TypeId.OnStoppedAtEdgeId => new SAOnStoppedAtLedge(),
                    TypeId.OnLandId => new SAOnLand(),
                    TypeId.OnCancelId => new SAOnCancel(),
                    TypeId.RefreshAtkId => new SARefreshAttack(),
                    TypeId.EndAtkId => new SAEndAttack(),
                    TypeId.SetHitboxCountId => new SASetHitboxCount(),
                    TypeId.ConfigHitboxId => new SAConfigHitbox(),
                    TypeId.SetAtkPropId => new SASetAttackProp(),
                    TypeId.ManipHitboxId => new SAManipHitbox(),
                    TypeId.UpdateHurtsetId => new SAUpdateHurtboxes(),
                    TypeId.SetupHurtsetId => new SASetupHurtboxes(),
                    TypeId.ManipHurtboxId => new SAManipHurtbox(),
                    TypeId.BoneStateId => new SABoneState(),
                    TypeId.BoneScaleId => new SABoneScale(),
                    TypeId.SpawnAgentId => new SASpawnAgent(),
                    TypeId.LocalFXId => new SALocalFX(),
                    TypeId.SpawnFXId => new SASpawnFX(),
                    TypeId.HitboxFXId => new SASetHitboxFX(),
                    TypeId.SFXId => new SAPlaySFX(),
                    TypeId.HitboxSFXId => new SASetHitboxSFX(),
                    TypeId.ColorTintId => new SAColorTint(),
                    TypeId.FindFloorId => new SAFindFloor(),
                    TypeId.HurtGrabbedId => new SAHurtGrabbed(),
                    TypeId.LaunchGrabbedId => new SALaunchGrabbed(),
                    TypeId.StateCancelGrabbedId => new SAStateCancelGrabbed(),
                    TypeId.EndGrabId => new SAEndGrab(),
                    TypeId.GrabNotifyEscapeId => new SAGrabNotifyEscape(),
                    TypeId.IgnoreGrabbedId => new SAIgnoreGrabbed(),
                    TypeId.EventKOId => new SAEventKO(),
                    TypeId.EventKOGrabbedId => new SAEventKOGrabbed(),
                    TypeId.CameraShakeId => new SACameraShake(),
                    TypeId.ResetOnHitId => new SAResetOnHits(),
                    TypeId.OnHitId => new SAOnHit(),
                    TypeId.FastForwardId => new SAFastForwardState(),
                    TypeId.TimingTweakId => new SATimingTweak(),
                    TypeId.MapAnimId => new SAMapAnimation(),
                    TypeId.AlterMoveDtId => new SAAlterMoveDT(),
                    TypeId.AlterMoveVelId => new SAAlterMoveVel(),
                    TypeId.SetStagePartId => new SASetStagePart(),
                    TypeId.SetStagePartsDefaultId => new SASetStagePartsDefault(),
                    TypeId.JumpId => new SAJump(),
                    TypeId.StopJumpId => new SAStopJump(),
                    TypeId.ManageAirJumpId => new SAManageAirJump(),
                    TypeId.LeaveGroundId => new SALeaveGround(),
                    TypeId.UnhogEdgeId => new SAUnHogEdge(),
                    TypeId.SFXTimelineId => new SAPlaySFXTimeline(),
                    TypeId.FindLastHorizontalInputId => new SAFindLastHorizontalInput(),
                    TypeId.SetCommandGrab => new SASetCommandGrab(),
                    TypeId.CameraPunchId => new SACameraPunch(),
                    TypeId.SpawnAgent2Id => new SASpawnAgent2(),
                    TypeId.ManipDecorChainId => new SAManipDecorChain(),
                    TypeId.UpdateHitboxesId => new SAUpdateHitboxes(),
                    TypeId.SampleAnimId => new SASampleAnim(),
                    TypeId.ForceExtraInputId => new SAForceExtraInputCheck(),
                    TypeId.LaunchGrabbedCustomId => new SALaunchGrabbedCustom(),
                    TypeId.BaseIdentifier => new StateAction(),
                    _ => throw new JsonException(),
                });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] StateAction value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo, versionInfo);
        }
    }
}