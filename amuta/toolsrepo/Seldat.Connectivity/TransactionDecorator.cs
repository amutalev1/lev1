using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Configuration;
using System.Diagnostics;

namespace Seldat.Connectivity
{
    /// <summary>
    /// TransactionDecorator wraps (decorates) the built-in TransactionScope class 
    /// </summary>
    public sealed class TransactionDecorator : IDisposable
    {
        private TransactionScope _scope;
        private Transaction _transactionToUse;
        private TransactionScopeOption _scopeOption;
        private TransactionScopeAsyncFlowOption _asyncFlowOption;
        private TimeSpan _scopeTimeout;
        private TransactionOptions _transactionOptions;
        private EnterpriseServicesInteropOption _interopOption;

        // Get database configuration from config.web file.
        private static readonly string _dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly BooleanSwitch _useTransuctions = new BooleanSwitch("TransactionDecorator", "Switch to controle transactions.");
        // All constructors wrap (decorate) constructors from the 
        // built-in TransactionScope class.
        #region Overloaded Constructors

        /// <summary>
        /// Initializes a new instance of TransactionDecorator. 
        /// Sets up the internal transaction scope variable.
        /// </summary>
        public TransactionDecorator()
        {
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope();
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class and sets the 
        /// specified transaction as the ambient transaction, so that transactional 
        /// work done inside the scope uses this transDoFactory.
        /// </summary>
        /// <param name="transactionToUse">Represents a transaction.</param>
        public TransactionDecorator(Transaction transactionToUse)
        {
            _transactionToUse = transactionToUse;
            if (_dataProvider != "System.Data.OleDb")
                _scope = new TransactionScope(_transactionToUse);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class with the specified requirements. 
        /// </summary>
        /// <param name="scopeOption">Provides additional options for creating a TransactionDecorator.</param>
        public TransactionDecorator(TransactionScopeOption scopeOption)
        {
            _scopeOption = scopeOption;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_scopeOption);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class with the specified requirements. 
        /// </summary>
        /// <param name="asyncFlowOption">Provides TransactionScopeAsyncFlowOption for creating a TransactionDecorator.</param>
        public TransactionDecorator(TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _asyncFlowOption = asyncFlowOption;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_asyncFlowOption);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class 
        /// with the specified timeout value, and sets the specified 
        /// transaction as the ambient transaction, so that transactional 
        /// work done inside the scope uses this transDoFactory. 
        /// </summary>
        /// <param name="transactionToUse">Represents a transaction.</param>
        /// <param name="scopeTimeout">The TimeSpan after which the transaction scope times out and aborts the transaction.</param>
        public TransactionDecorator(Transaction transactionToUse, TimeSpan scopeTimeout)
        {
            _transactionToUse = transactionToUse;
            _scopeTimeout = scopeTimeout;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_transactionToUse, _scopeTimeout);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class 
        /// with the specified timeout value and requirements.
        /// </summary>
        /// <param name="scopeOption">TransactionScopeOption enumeration that describes the transaction requirements associated with this transaction scope.</param>
        /// <param name="scopeTimeout">The TimeSpan after which the transaction scope times out and aborts the transaction.</param>
        public TransactionDecorator(TransactionScopeOption scopeOption, TimeSpan scopeTimeout)
        {
            _scopeOption = scopeOption;
            _scopeTimeout = scopeTimeout;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_scopeOption, _scopeTimeout);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class with the specified requirements.
        /// </summary>
        /// <param name="scopeOption">TransactionScopeOption enumeration that describes the transaction requirements associated with this transaction scope.</param>
        /// <param name="transactionOptions">A TransactionOptions structure that describes the transaction options to use if a new transaction is created. If an existing transaction is used, the timeout value in this parameter applies to the transaction scope. If that time expires before the scope is disposed, the transaction is aborted.</param>
        public TransactionDecorator(TransactionScopeOption scopeOption, TransactionOptions transactionOptions)
        {
            _scopeOption = scopeOption;
            _transactionOptions = transactionOptions;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_scopeOption, _transactionOptions);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class with the specified 
        /// timeout value and COM+ interoperability requirements, and sets the specified 
        /// transaction as the ambient transaction, so that transactional work done inside 
        /// the scope uses this transDoFactory. 
        /// </summary>
        /// <param name="transactionToUse">Represents a transaction.</param>
        /// <param name="scopeTimeout">The TimeSpan after which the transaction scope times out and aborts the transaction.</param>
        /// <param name="interopOption">An instance of the EnterpriseServicesInteropOption enumeration that describes how the associated transaction interacts with COM+ transactions.</param>
        public TransactionDecorator(Transaction transactionToUse, TimeSpan scopeTimeout, EnterpriseServicesInteropOption interopOption)
        {
            _transactionToUse = transactionToUse;
            _scopeTimeout = scopeTimeout;
            _interopOption = interopOption;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_transactionToUse, _scopeTimeout, _interopOption);
        }

        /// <summary>
        /// Initializes a new instance of the TransactionScope class with the 
        /// specified scope and COM+ interoperability requirements, and 
        /// transaction options.
        /// </summary>
        /// <param name="scopeOption">TransactionScopeOption enumeration that describes the transaction requirements associated with this transaction scope.</param>
        /// <param name="transactionOptions">A TransactionOptions structure that describes the transaction options to use if a new transaction is created. If an existing transaction is used, the timeout value in this parameter applies to the transaction scope. If that time expires before the scope is disposed, the transaction is aborted.</param>
        /// <param name="interopOption">An instance of the EnterpriseServicesInteropOption enumeration that describes how the associated transaction interacts with COM+ transactions.</param>
        public TransactionDecorator(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, EnterpriseServicesInteropOption interopOption)
        {
            _scopeOption = scopeOption;
            _transactionOptions = transactionOptions;
            _interopOption = interopOption;
            if (_dataProvider != "System.Data.OleDb" && _useTransuctions.Enabled)
                _scope = new TransactionScope(_scopeOption, _transactionOptions, _interopOption);
        }

        #endregion

        /// <summary>
        /// Indicates that all operations within the scope are completed succesfully.
        /// </summary>
        public void Complete()
        {
            if (_scope != null)
                _scope.Complete();
        }

        #region IDisposable members

        /// <summary>
        /// Ends and disposes the transaction scope.
        /// </summary>
        public void Dispose()

        {
            if (_dataProvider != "System.Data.OleDb")
                if (_scope != null)
                    _scope.Dispose();
        }

        #endregion
    }
}
