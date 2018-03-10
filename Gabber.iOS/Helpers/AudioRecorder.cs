﻿using System;
using System.IO;
using AVFoundation;
using Foundation;

namespace Gabber.iOS.Helpers
{
    public class AudioRecorder
    {
        AVAudioRecorder recorder;
        // The recorder manages state of file to reduce logic in controllers
        string filename;
		// Setup on construction to reduce load time when recording
        public AudioRecorder() => SetupRecorder();

        void SetupRecorder()
        {
            // An extension is required otherwise the file does not save to a format that browsers support (mp4)
            // Note: output the file rather than the path as the path is calculated via PrivatePath interface in the PCL
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filename = Path.Combine(documents, DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + ".m4a");

            var audioSession = AVAudioSession.SharedInstance();
            var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            err = audioSession.SetActive(true);

            NSObject[] values = {
                NSNumber.FromFloat (44100.0f),
                NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.MPEG4AAC),
                NSNumber.FromInt32 (2),
                NSNumber.FromInt32 (16),
                NSNumber.FromInt32 ((int) AVAudioQuality.High),
                NSNumber.FromBoolean (false),
                NSNumber.FromBoolean (false)
            };

            NSObject[] keys = {
                AVAudioSettings.AVSampleRateKey,
                AVAudioSettings.AVFormatIDKey,
                AVAudioSettings.AVNumberOfChannelsKey,
                AVAudioSettings.AVLinearPCMBitDepthKey,
                AVAudioSettings.AVEncoderAudioQualityKey,
                AVAudioSettings.AVLinearPCMIsBigEndianKey,
                AVAudioSettings.AVLinearPCMIsFloatKey
            };

            recorder = AVAudioRecorder.Create(
                NSUrl.FromFilename(filename), 
                new AudioSettings(NSDictionary.FromObjectsAndKeys(values, keys)), 
                out var error
            );
        }

        public void Record() => recorder.Record();
        public bool IsRecording() => recorder.Recording;
        public int CurrentTime() => (int)recorder.currentTime;

        public string FinishRecording () 
        {
            recorder.Stop();
            recorder.Dispose();
            return filename;
        }
    }
}