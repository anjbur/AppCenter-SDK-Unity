// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if UNITY_IOS && !UNITY_EDITOR
using System;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Mobile.Unity.Distribute.Internal
{
    class DistributeInternal
    {
        public static void Initialize()
        {
            DistributeDelegate.SetDelegate();
        }

        public static void PostInitialize()
        {
        }
        
        public static IntPtr GetNativeType()
        {
            return mobile_center_unity_distribute_get_type();
        }

        public static MobileCenterTask SetEnabledAsync(bool isEnabled)
        {
            mobile_center_unity_distribute_set_enabled(isEnabled);
            return MobileCenterTask.FromCompleted();
        }

        public static MobileCenterTask<bool> IsEnabledAsync()
        {
            var isEnabled = mobile_center_unity_distribute_is_enabled();
            return MobileCenterTask<bool>.FromCompleted(isEnabled);
        }

        public static void SetInstallUrl(string installUrl)
        {
            mobile_center_unity_distribute_set_install_url(installUrl);
        }

        public static void SetApiUrl(string apiUrl)
        {
            mobile_center_unity_distribute_set_api_url(apiUrl);
        }

        public static void NotifyUpdateAction(int updateAction)
        {
            mobile_center_unity_distribute_notify_update_action(updateAction);
        }

#region External

        [DllImport("__Internal")]
        private static extern IntPtr mobile_center_unity_distribute_get_type();

        [DllImport("__Internal")]
        private static extern void mobile_center_unity_distribute_set_enabled(bool isEnabled);

        [DllImport("__Internal")]
        private static extern bool mobile_center_unity_distribute_is_enabled();

        [DllImport("__Internal")]
        private static extern void mobile_center_unity_distribute_set_install_url(string installUrl);

        [DllImport("__Internal")]
        private static extern void mobile_center_unity_distribute_set_api_url(string apiUrl);

        [DllImport("__Internal")]
        private static extern void mobile_center_unity_distribute_notify_update_action(int updateAction);

#endregion
    }
}
#endif