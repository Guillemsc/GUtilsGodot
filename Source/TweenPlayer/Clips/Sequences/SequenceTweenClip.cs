// using System.Collections.Generic;
// using DG.Tweening;
// using GUtils.TweenPlayers.Clips.Base;
// using GUtils.TweenPlayers.Entries;
// using GUtils.Tweening.Extensions;
//
// namespace GUtils.TweenPlayers.Clips.Sequences
// {
//     public sealed class SequenceTweenClip : MonoBehaviourTweenClip
//     {
//         public List<SequenceEntry> Entries;
//
//         public override void Create(ref Sequence sequence)
//         {
//             foreach (SequenceEntry entry in Entries)
//             {
//                 if (entry.Clip == null)
//                 {
//                     continue;
//                 }
//
//                 sequence.Add(entry);
//             }
//         }
//     }
// }
