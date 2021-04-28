// Copyright (c) 2018-present, Facebook, Inc. 
// @generated
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.0
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace TBE {

public class NativeSpatDecoderQueue : SpatDecoderInterface {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal NativeSpatDecoderQueue(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Audio360CSharpPINVOKE.NativeSpatDecoderQueue_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  public static global::System.Runtime.InteropServices.HandleRef getCPtr(NativeSpatDecoderQueue obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  protected override void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  public virtual int getFreeSpaceInQueue(ChannelMap channelMap) {
    int ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_getFreeSpaceInQueue(swigCPtr, (int)channelMap);
    return ret;
  }

  public virtual int getQueueSize(ChannelMap channelMap) {
    int ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_getQueueSize(swigCPtr, (int)channelMap);
    return ret;
  }

  public virtual int enqueueData(float[] interleavedBuffer, int numTotalSamples, ChannelMap channelMap) {
    int ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_enqueueData__SWIG_0(swigCPtr, interleavedBuffer, numTotalSamples, (int)channelMap);
    return ret;
  }

  public virtual int enqueueData(short[] interleavedBuffer, int numTotalSamples, ChannelMap channelMap) {
    int ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_enqueueData__SWIG_1(swigCPtr, interleavedBuffer, numTotalSamples, (int)channelMap);
    return ret;
  }

  public virtual int enqueueSilence(int numTotalSamples, ChannelMap channelMap) {
    int ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_enqueueSilence(swigCPtr, numTotalSamples, (int)channelMap);
    return ret;
  }

  public virtual void flushQueue() {
    Audio360CSharpPINVOKE.NativeSpatDecoderQueue_flushQueue(swigCPtr);
  }

  public virtual ulong getNumSamplesDequeuedPerChannel() {
    ulong ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_getNumSamplesDequeuedPerChannel(swigCPtr);
    return ret;
  }

  public virtual void setEndOfStream(bool endOfStream) {
    Audio360CSharpPINVOKE.NativeSpatDecoderQueue_setEndOfStream(swigCPtr, endOfStream);
  }

  public virtual bool getEndOfStreamStatus() {
    bool ret = Audio360CSharpPINVOKE.NativeSpatDecoderQueue_getEndOfStreamStatus(swigCPtr);
    return ret;
  }

}

}