﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console.Wpf.Tests.VSTS.DevTests.Contexts;
using Console.Wpf.ViewModel.Commands;
using Console.Wpf.ViewModel;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Console.Wpf.Tests.VSTS.TestSupport;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;

namespace Console.Wpf.Tests.VSTS.DevTests
{
    public abstract class given_empty_configuration_model : ContainerContext
    {
    }

    [TestClass]
    public class when_executing_add_block_command : given_empty_configuration_model
    {
        bool commandCanExecuteCalled;
        AddApplicationBlockCommand addBlockCommand;
        ConfigurationSourceModel configurationModel;

        protected override void Arrange()
        {
            base.Arrange();

            configurationModel = Container.Resolve<ConfigurationSourceModel>();
            AddApplicationBlockCommandAttribute attribute = new AddApplicationBlockCommandAttribute("Add App Settings", "appSettings", typeof(AppSettingsSection));
            addBlockCommand = new AddApplicationBlockCommand(configurationModel, attribute);
            addBlockCommand.CanExecuteChanged += (sender, args) => { commandCanExecuteCalled = true; };
        }

        protected override void Act()
        {
            addBlockCommand.Execute(null);
        }


        [TestMethod]
        public void then_block_is_added_to_configuration_model()
        {
            Assert.IsTrue(configurationModel.Sections.Where(x => x.ConfigurationType == typeof(AppSettingsSection)).Any());
        }

        [TestMethod]
        public void then_configuration_section_has_section()
        {
            Assert.IsTrue(configurationModel.HasSection("appSettings"));
        }

        [TestMethod]
        public void then_command_cannot_be_executed_again()
        {
            Assert.IsFalse(addBlockCommand.CanExecute(null));
        }

        [TestMethod]
        public void then_can_execute_changed_was_called()
        {
            Assert.IsTrue(commandCanExecuteCalled);
        }

    }
}