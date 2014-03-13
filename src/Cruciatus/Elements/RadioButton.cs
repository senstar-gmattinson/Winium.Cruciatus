﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RadioButton.cs" company="2GIS">
//   Cruciatus
// </copyright>
// <summary>
//   Представляет элемент управления переключатель.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Cruciatus.Elements
{
    using System;
    using System.Windows.Automation;
    using System.Windows.Forms;

    using Cruciatus.Exceptions;
    using Cruciatus.Extensions;
    using Cruciatus.Interfaces;

    /// <summary>
    /// Представляет элемент управления переключатель.
    /// </summary>
    public class RadioButton : CruciatusElement, IContainerElement, IListElement, IClickable
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RadioButton"/>.
        /// </summary>
        public RadioButton()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RadioButton"/>.
        /// </summary>
        /// <param name="parent">
        /// Элемент, являющийся родителем для переключателя.
        /// </param>
        /// <param name="automationId">
        /// Уникальный идентификатор переключателя.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Входные параметры не должны быть нулевыми.
        /// </exception>
        public RadioButton(AutomationElement parent, string automationId)
        {
            this.Initialize(parent, automationId);
        }

        /// <summary>
        /// Возвращает координаты точки, внутри переключателя, которые можно использовать для нажатия.
        /// </summary>
        /// <exception cref="PropertyNotSupportedException">
        /// Переключатель не поддерживает данное свойство.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// При получении значения свойства не удалось привести его к ожидаемому типу.
        /// </exception>
        public System.Drawing.Point ClickablePoint
        {
            get
            {
                var windowsPoint = this.GetPropertyValue<System.Windows.Point>(AutomationElement.ClickablePointProperty);

                return new System.Drawing.Point((int)windowsPoint.X, (int)windowsPoint.Y);
            }
        }
        
        /// <summary>
        /// Возвращает текстовое представление имени класса.
        /// </summary>
        internal override string ClassName
        {
            get
            {
                return "RadioButton";
            }
        }

        internal override ControlType GetType
        {
            get
            {
                return ControlType.RadioButton;
            }
        }

        /// <summary>
        /// Выполняет нажатие по переключателю кнопкой по умолчанию.
        /// </summary>
        /// <returns>
        /// Значение true если нажать на элемент удалось; в противном случае значение - false.
        /// </returns>
        public bool Click()
        {
            return this.Click(CruciatusFactory.Settings.ClickButton);
        }

        /// <summary>
        /// Выполняет нажатие по переключателю.
        /// </summary>
        /// <param name="mouseButton">
        /// Задает кнопку мыши, которой будет произведено нажатие.
        /// </param>
        /// <returns>
        /// Значение true если нажать на текстовый блок удалось; в противном случае значение - false.
        /// </returns>
        public bool Click(MouseButtons mouseButton)
        {
            try
            {
                CruciatusCommand.Click(this.ClickablePoint, mouseButton);
            }
            catch (CruciatusException exc)
            {
                this.LastErrorMessage = exc.Message;
                return false;
            }

            return true;
        }

        void IContainerElement.Initialize(AutomationElement parent, string automationId)
        {
            this.Initialize(parent, automationId);
        }

        void IListElement.Initialize(AutomationElement element)
        {
            this.Initialize(element);
        }
    }
}