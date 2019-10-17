#if USE_CINEMACHINE
#if UNITY_2017_1_OR_NEWER
using UnityEngine;
using Cinemachine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    /// <summary>
    /// Sequencer commannd CinemachinePriority(vcam, [priority], [cut])
    /// 
    /// Sets the priority of a Cinemachine virtual camera.
    /// 
    /// - vcam: The name of a GameObject containing a CinemachineVirtualCamera.
    /// - priority: (Optional) New priority level. Default: 999.
    /// - cut: (Optional) Cuts to the vcam instead of allowing Cinemachine to ease there.
    /// </summary>
    public class SequencerCommandCinemachinePriority : SequencerCommand
    {

        public System.Collections.IEnumerator Start()
        {
            var subject = GetSubject(0);
            var vcam = (subject != null) ? subject.GetComponent<CinemachineVirtualCamera>() : null;
            var priority = GetParameterAsInt(1, 999);
            var cut = string.Equals(GetParameter(2), "cut", System.StringComparison.OrdinalIgnoreCase);
            if (vcam == null)
            {
                if (DialogueDebug.LogWarnings) Debug.LogWarning("Dialogue System: Sequencer: CinemachinePriority(" + GetParameters() +
                    "): Can't find virtual camera '" + GetParameter(0) + ".");
            }
            else
            {
                if (DialogueDebug.LogInfo) Debug.Log("Dialogue System: Sequencer: CinemachinePriority(" + vcam + ", " + priority + ")");
                vcam.Priority = priority;
                if (cut)
                {
                    var cinemachineBrain = FindObjectOfType<CinemachineBrain>();
                    if (cinemachineBrain != null)
                    {
                        var previousBlendTime = cinemachineBrain.m_DefaultBlend.m_Time;
                        cinemachineBrain.m_DefaultBlend.m_Time = 0;
                        yield return null;
                        yield return null;
                        cinemachineBrain.m_DefaultBlend.m_Time = previousBlendTime;
                    }
                }
            }
            Stop();
        }

    }

}
#endif
#endif
