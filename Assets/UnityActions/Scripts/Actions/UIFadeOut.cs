﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;



namespace CC
{
    /// <summary>
    /// Class UIFadeOut. Class that makes the action of fading a Canvas Group.
    /// Warning This only works with UI elements, do not use 3D elements </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member 
    /// through the remarks tag</remarks>
    public class UIFadeOut : ActionInterval
    {
        private float startAlpha = 1.0f;
        private float endAlpha = 0.0f;
        private CanvasRenderer canvasRenderer;
        private CanvasGroup canvasGroup;
        private UISetup UIMode;

        /// <summary>
        /// The class constructor. </summary>
        public UIFadeOut(float duration = 1.0f) : base(duration)
        {

        }

        public override Action Reverse()
        {
            return null;
        }

        public override Action Clone()
        {
            return null;
        }

        public override void LerpAction(float delta)
        {
            if (UIMode == UISetup.canvasRenderer)
            {
                canvasRenderer.SetAlpha(Mathf.Lerp(startAlpha, endAlpha, delta));
            }
            else if (UIMode == UISetup.canvasGroup)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, delta);
            }
        }

        public override void StartWithTarget(Transform inTarget)
        {
            base.StartWithTarget(inTarget);
            if (inTarget.GetComponent<CanvasRenderer>() != null)
            {
                UIMode = UISetup.canvasRenderer;
                canvasRenderer = inTarget.GetComponent<CanvasRenderer>();
                canvasRenderer.SetAlpha(1.0f);
            }
            else if (inTarget.GetComponent<CanvasGroup>() != null)
            {
                UIMode = UISetup.canvasGroup;
                canvasGroup = inTarget.GetComponent<CanvasGroup>();
                canvasGroup.alpha = 1.0f;
            }
            else
            {
                Debug.LogError("This object doesn't have CanvasRenderer or CanvasGroup");
            }
        }
    }
}