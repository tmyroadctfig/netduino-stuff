//-----------------------------------------------------------------------------
//
//    ** DO NOT EDIT THIS FILE! **
//    This file was generated by a tool
//    re-running the tool will overwrite this file.
//
//-----------------------------------------------------------------------------


#include "CW_NETMF_OneWire.h"
#include "CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire.h"

using namespace CW::NETMF::Hardware;


HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::_ctor___VOID__MicrosoftSPOTHardwareMicrosoftSPOTHardwareCpuPin( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        void param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_void( stack, 1, param0 ) );

        OneWire::_ctor( pMngObj,  param0, hr );
        TINYCLR_CHECK_HRESULT( hr );
    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::Reset___BOOLEAN( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        INT8 retVal = OneWire::Reset( pMngObj,  hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_INT8( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::Read___I4__SZARRAY_U1__I4__I4( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        CLR_RT_TypedArray_UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8_ARRAY( stack, 1, param0 ) );

        INT32 param1;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 2, param1 ) );

        INT32 param2;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 3, param2 ) );

        INT32 retVal = OneWire::Read( pMngObj,  param0, param1, param2, hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_INT32( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::ReadBit___U1( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        UINT8 retVal = OneWire::ReadBit( pMngObj,  hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_UINT8( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::ReadByte___U1( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        UINT8 retVal = OneWire::ReadByte( pMngObj,  hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_UINT8( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::Write___VOID__SZARRAY_U1__I4__I4( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        CLR_RT_TypedArray_UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8_ARRAY( stack, 1, param0 ) );

        INT32 param1;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 2, param1 ) );

        INT32 param2;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 3, param2 ) );

        OneWire::Write( pMngObj,  param0, param1, param2, hr );
        TINYCLR_CHECK_HRESULT( hr );
    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::WriteBit___VOID__U1( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8( stack, 1, param0 ) );

        OneWire::WriteBit( pMngObj,  param0, hr );
        TINYCLR_CHECK_HRESULT( hr );
    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::WriteByte___VOID__U1( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8( stack, 1, param0 ) );

        OneWire::WriteByte( pMngObj,  param0, hr );
        TINYCLR_CHECK_HRESULT( hr );
    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::Search___I4__SZARRAY_U1__I4__I4( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_HeapBlock* pMngObj = Interop_Marshal_RetrieveManagedObject( stack );

        FAULT_ON_NULL(pMngObj);

        CLR_RT_TypedArray_UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8_ARRAY( stack, 1, param0 ) );

        INT32 param1;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 2, param1 ) );

        INT32 param2;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 3, param2 ) );

        INT32 retVal = OneWire::Search( pMngObj,  param0, param1, param2, hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_INT32( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::ComputeCRC___STATIC__U1__SZARRAY_U1__I4__I4__U1( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_TypedArray_UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8_ARRAY( stack, 0, param0 ) );

        INT32 param1;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 1, param1 ) );

        INT32 param2;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 2, param2 ) );

        UINT8 param3;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8( stack, 3, param3 ) );

        UINT8 retVal = OneWire::ComputeCRC( param0, param1, param2, param3, hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_UINT8( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}

HRESULT Library_CW_NETMF_OneWire_CW_NETMF_Hardware_OneWire::ComputeCRC16___STATIC__U2__SZARRAY_U1__I4__I4__U2( CLR_RT_StackFrame& stack )
{
    TINYCLR_HEADER(); hr = S_OK;
    {
        CLR_RT_TypedArray_UINT8 param0;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT8_ARRAY( stack, 0, param0 ) );

        INT32 param1;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 1, param1 ) );

        INT32 param2;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_INT32( stack, 2, param2 ) );

        UINT16 param3;
        TINYCLR_CHECK_HRESULT( Interop_Marshal_UINT16( stack, 3, param3 ) );

        UINT16 retVal = OneWire::ComputeCRC16( param0, param1, param2, param3, hr );
        TINYCLR_CHECK_HRESULT( hr );
        SetResult_UINT16( stack, retVal );

    }
    TINYCLR_NOCLEANUP();
}
