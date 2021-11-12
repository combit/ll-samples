
/*
**
**    Created by PROGRESS ProxyGen (Progress Version 11.7) Wed Sep 09 16:34:52 CEST 2020
**
*/

//
// OpenEdgeProxy
//


namespace TasteITConsulting.Reporting
{
    using System;
    using Progress.Open4GL;
    using Progress.Open4GL.Exceptions;
    using Progress.Open4GL.Proxy;
    using Progress.Open4GL.DynamicAPI;
    using Progress.Common.EhnLog;
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// 
    /// @author Thomas Wurl
    /// 
    /// </summary>
    public class OpenEdgeProxy : AppObject
    {
        private static int proxyGenVersion = 1;
        private const  int PROXY_VER = 5;

    // Create a MetaData object for each temp-table parm used in any and all methods.
    // Create a Schema object for each method call that has temp-table parms which
    // points to one or more temp-tables used in that method call.



        static OpenEdgeProxy()
        {

        }


    //---- Constructors
    public OpenEdgeProxy(Connection connectObj) : this(connectObj, false)
    {       
    }
    
    // If useWebConfigFile = true, we are creating AppObject to use with Silverlight proxy
    public OpenEdgeProxy(Connection connectObj, bool useWebConfigFile)
    {
        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            if ((connectObj.Url == null) || (connectObj.Url.Equals("")))
                connectObj.Url = "OpenEdgeProxy";

            if (useWebConfigFile == true)
                connectObj.GetWebConfigFileInfo("OpenEdgeProxy");

            initAppObject("OpenEdgeProxy",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
   
    public OpenEdgeProxy(string urlString,
                        string userId,
                        string password,
                        string appServerInfo)
    {
        Connection connectObj;

        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            connectObj = new Connection(urlString,
                                        userId,
                                        password,
                                        appServerInfo);

            initAppObject("OpenEdgeProxy",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

            /* release the connection since the connection object */
            /* is being destroyed.  the user can't do this        */
            connectObj.ReleaseConnection();

        }
        catch (System.Exception e)
        {
            throw e;
        }
    }


    public OpenEdgeProxy(string userId,
                        string password,
                        string appServerInfo)
    {
        Connection connectObj;

        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            connectObj = new Connection("OpenEdgeProxy",
                                        userId,
                                        password,
                                        appServerInfo);

            initAppObject("OpenEdgeProxy",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

            /* release the connection since the connection object */
            /* is being destroyed.  the user can't do this        */
            connectObj.ReleaseConnection();
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public OpenEdgeProxy()
    {
        Connection connectObj;

        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            connectObj = new Connection("OpenEdgeProxy",
                                        null,
                                        null,
                                        null);

            initAppObject("OpenEdgeProxy",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

            /* release the connection since the connection object */
            /* is being destroyed.  the user can't do this        */
            connectObj.ReleaseConnection();
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

        /// <summary>
	/// 
	/// </summary> 
	public string OpenEdgeGateway(string pcServiceName, string pcMethodName, string plcServiceParameterJson, string plcRequest, out string plcResponse)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(5);

		// Set up input parameters
		parms.setStringParameter(1, pcServiceName, ParameterSet.INPUT);
		parms.setStringParameter(2, pcMethodName, ParameterSet.INPUT);
		parms.setStringParameter(3, plcServiceParameterJson, ParameterSet.INPUT);
		parms.setLongCharParameter(4, plcRequest, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(5, null, ParameterSet.OUTPUT);


		// Setup local MetaSchema if any params are tables



		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("ListLabel/OpenEdgeAdapter/OpenEdgeGateway.p", parms);


		// Get output parameters
		outValue = parms.getOutputParameter(5);
		plcResponse = (string)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}



    }
}

