﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;
using sccmclictr.automation;

namespace ClientCenter
{
    /// <summary>
    /// Interaction logic for InstallReapir.xaml
    /// </summary>
    public partial class InstallRepair : UserControl
    {
        private SCCMAgent oAgent;
        public MyTraceListener Listener;

        public InstallRepair()
        {
            InitializeComponent();
        }
        public SCCMAgent SCCMAgentConnection
        {
            get
            {
                return oAgent;
            }
            set
            {
                if (value.isConnected)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    try
                    {
                        oAgent = value;

                    }
                    catch { }
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            }
        }

        private void bt_CleanupMessageQueue_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                oAgent.Client.AgentActions.CleanupMessageQueue();
            }
            catch(Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_WMICheck_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
               Listener.WriteLine(oAgent.Client.Health.WMIVerifyRepository());
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_WMISalvage_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Listener.WriteLine(oAgent.Client.Health.WMISalvageRepository());
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_WMIReset_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Listener.WriteLine(oAgent.Client.Health.WMIResetRepository());
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_RegDLL_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                foreach(string sFile in Properties.Settings.Default.RegisterDLLs)
                {
                    oAgent.Client.Health.RegsiertDLL(sFile);
                }
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_DCOMGetDefaultLaunchPermission_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Listener.WriteLine("DefaultLaunchPermission: " + oAgent.Client.Health.GetDCOMPerm(@"SOFTWARE\Microsoft\Ole", "DefaultLaunchPermission"));
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_DCOMSetDefaultLaunchPermission_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                string sDefaultACL = Properties.Settings.Default.DefaultLaunchPermission;
                oAgent.Client.Health.SetDCOMPerm(@"SOFTWARE\Microsoft\Ole", "DefaultLaunchPermission", sDefaultACL);
                Listener.WriteLine("DefaultLaunchPermission set to:" + sDefaultACL);
                
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_DCOMGetMachineAccessRestriction_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Listener.WriteLine("MachineAccessRestriction: " + oAgent.Client.Health.GetDCOMPerm(@"SOFTWARE\Microsoft\Ole", "MachineAccessRestriction"));
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_DCOMSetMachineAccessRestriction_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                string sDefaultACL = Properties.Settings.Default.MachineAccessRestriction;
                oAgent.Client.Health.SetDCOMPerm(@"SOFTWARE\Microsoft\Ole", "MachineAccessRestriction", sDefaultACL);
                Listener.WriteLine("MachineAccessRestriction set to:" + sDefaultACL);

            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_DCOMGetMachineLaunchRestriction_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Listener.WriteLine("MachineLaunchRestriction: " + oAgent.Client.Health.GetDCOMPerm(@"SOFTWARE\Microsoft\Ole", "MachineLaunchRestriction"));
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bt_DCOMSetMachineLaunchRestriction_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                string sDefaultACL = Properties.Settings.Default.MachineLaunchRestriction;
                oAgent.Client.Health.SetDCOMPerm(@"SOFTWARE\Microsoft\Ole", "MachineLaunchRestriction", sDefaultACL);
                Listener.WriteLine("MachineLaunchRestriction set to:" + sDefaultACL);
            }
            catch (Exception ex)
            {
                Listener.WriteError(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

    }
}
