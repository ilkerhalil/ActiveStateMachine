using System;
using System.Drawing;
using System.Windows.Forms;
using ApplicationServices;
using Common;
using TelephoneStateMachine;

namespace Telephone_UI
{
    public partial class Telephone : Form, IUserInterface
    {
        // private members
        private TelephoneStateMachine.TelephoneStateMachine _telephoneStateMachine;
        private ViewManager _viewMan;
        private TelephoneViewStateConfiguration _viewStateConfiguration;
        private DeviceManager _devMan;
        private TelephoneDeviceConfiguration _devManConfiguration;

        // Public
        public TelephoneViewState CurrentViewState { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Telephone()
        {
            // Standard Windows Forms initialization
            InitializeComponent();
        }

        /// <summary>
        /// Bootstrapping - Load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Telephone_Load(object sender, System.EventArgs e)
        {
            // Application Services
            // Initialize view states and view manager
            _viewStateConfiguration = new TelephoneViewStateConfiguration();
            _viewMan = ViewManager.Instance;
            _viewMan.LoadViewStateConfiguration(_viewStateConfiguration, this);

            // Load devices controlled by state machine into device manager
            _devManConfiguration = new TelephoneDeviceConfiguration();
            _devMan = DeviceManager.Instance;
            _devMan.LoadDeviceConfiguration(_devManConfiguration);
            
            // State machine
            // Initialize state machine and start state machine
            _telephoneStateMachine = new TelephoneStateMachine.TelephoneStateMachine(new TelephoneStateMachineConfiguration());
            _telephoneStateMachine.InitStateMachine();
            _telephoneStateMachine.Start();
        }

        

        #region IUserInterface implementation
        /// <summary>
        /// Loads a view state
        /// </summary>
        /// <param name="viewState"></param>
        public void LoadViewState(string viewState)
        {
            if (viewState == "CompleteFailure")
            {
                var result = MessageBox.Show("Application failed irreparably and will be shut down.", "Global Error",
                    MessageBoxButtons.OK);
                Invoke(new MethodInvoker(Close));
                return;
            }
            var telephoneViewState = (TelephoneViewState)_viewMan.ViewStateConfiguration.ViewStates[viewState];
            SetValues(telephoneViewState);
            CurrentViewState = telephoneViewState;
        }

        #endregion

        /// <summary>
        /// Sets all values in UI corresponding to given view state
        /// </summary>
        /// <param name="viewState"></param>
        private void SetValues(object viewState)
        {
            var telephoneViewState = (TelephoneViewState) viewState;
            // Bell
            if (telephoneViewState.Bell)
            {
                // tread-safe Windows Form property update
                this.Invoke(new MethodInvoker(() => labelBellValue.Text = "Ringing"));
                this.Invoke(new MethodInvoker(() => labelBellValue.BackColor = Color.Tomato));
            }
            else
            {
                this.Invoke(new MethodInvoker(() => labelBellValue.Text = "Silent"));
                this.Invoke(new MethodInvoker(() => labelBellValue.BackColor = Color.DarkSeaGreen));
            }

            // Line
            if (telephoneViewState.Line)
            {
                this.Invoke(new MethodInvoker(() => labelLineValue.Text = "Active"));
                this.Invoke(new MethodInvoker(() => labelLineValue.BackColor = Color.Tomato));
            }
            else
            {
                this.Invoke(new MethodInvoker(() => labelLineValue.Text = "Off"));
                this.Invoke(new MethodInvoker(() => labelLineValue.BackColor = Color.DarkSeaGreen));
            }

            // Receiver
            if (telephoneViewState.ReceiverHungUp)
            {
                this.Invoke(new MethodInvoker(() => labelReceiverValue.Text = "Down"));
                this.Invoke(new MethodInvoker(() => labelReceiverValue.BackColor = Color.DarkSeaGreen));
            }
            else
            {
                this.Invoke(new MethodInvoker(() => labelReceiverValue.Text = "Lifted"));
                this.Invoke(new MethodInvoker(() => labelReceiverValue.BackColor = Color.Tomato));
            }

            // Error handling
            if (telephoneViewState.Name == "ViewErrorPhoneRings") // Error display
            {
                this.Invoke(new MethodInvoker(() => label_CurViewStateValue.Text = " Bell is broken"));
                this.Invoke(new MethodInvoker(() => label_CurViewStateValue.BackColor = Color.Tomato));
            }
            else // Display current view state 
            {
                this.Invoke(new MethodInvoker(() => label_CurViewStateValue.Text = telephoneViewState.Name));
                this.Invoke(new MethodInvoker(() => label_CurViewStateValue.BackColor = Color.White));
            }
        }


        private void bttn_ReceiverDown_Click(object sender, System.EventArgs e)
        {
            #region Important hint!
            // Never do this -  the state machine must be the only place to handle state logic
            
            //if (CurrentViewState.Name == "ViewPhoneRings")
            //{
            //    _viewMan.RaiseUINotification("CallBlocked", "Receiver Hang Up button pressed in view state:" + CurrentViewState.Name);
            //}
            //else if (CurrentViewState.Name == "ViewTalking")
            //{
            //    _viewMan.RaiseUINotification("CallEnded", "Receiver Hang Up button pressed in view state:" + CurrentViewState.Name);
            //}
            #endregion

            // Just send a trigger and let the state machine do its work.
            _viewMan.RaiseUICommand("OnReceiverDown", "Receiver Hang Up button pressed in view state:" + CurrentViewState.Name,  "UI", "Receiver");
        }

        /// <summary>
        /// Send a command to device manager that the external line is active
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttn_Call_Click(object sender, System.EventArgs e)
        {
            if (CurrentViewState != null)
                _viewMan.RaiseUICommand("ActiveExternal","Initiate call button pressed in view state:" + CurrentViewState.Name, "UI", "PhoneLine");
        }

        private void bttn_ReceiverLift_Click(object sender, EventArgs e)
        {
            _viewMan.RaiseUICommand("OnReceiverUp", "Receiver-lift button pressed in view state:" + CurrentViewState.Name,  "UI", "Receiver");
        }

    }

}

