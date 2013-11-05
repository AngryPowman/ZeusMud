// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: 20001_S2CChatMessageNotify.proto

#ifndef PROTOBUF_20001_5fS2CChatMessageNotify_2eproto__INCLUDED
#define PROTOBUF_20001_5fS2CChatMessageNotify_2eproto__INCLUDED

#include <string>

#include <google/protobuf/stubs/common.h>

#if GOOGLE_PROTOBUF_VERSION < 2005000
#error This file was generated by a newer version of protoc which is
#error incompatible with your Protocol Buffer headers.  Please update
#error your headers.
#endif
#if 2005000 < GOOGLE_PROTOBUF_MIN_PROTOC_VERSION
#error This file was generated by an older version of protoc which is
#error incompatible with your Protocol Buffer headers.  Please
#error regenerate this file with a newer version of protoc.
#endif

#include <google/protobuf/generated_message_util.h>
#include <google/protobuf/message.h>
#include <google/protobuf/repeated_field.h>
#include <google/protobuf/extension_set.h>
#include <google/protobuf/unknown_field_set.h>
// @@protoc_insertion_point(includes)

namespace Protocol {

// Internal implementation detail -- do not call these.
void  protobuf_AddDesc_20001_5fS2CChatMessageNotify_2eproto();
void protobuf_AssignDesc_20001_5fS2CChatMessageNotify_2eproto();
void protobuf_ShutdownFile_20001_5fS2CChatMessageNotify_2eproto();

class S2CChatMessageNotify;

// ===================================================================

class S2CChatMessageNotify : public ::google::protobuf::Message {
 public:
  S2CChatMessageNotify();
  virtual ~S2CChatMessageNotify();

  S2CChatMessageNotify(const S2CChatMessageNotify& from);

  inline S2CChatMessageNotify& operator=(const S2CChatMessageNotify& from) {
    CopyFrom(from);
    return *this;
  }

  inline const ::google::protobuf::UnknownFieldSet& unknown_fields() const {
    return _unknown_fields_;
  }

  inline ::google::protobuf::UnknownFieldSet* mutable_unknown_fields() {
    return &_unknown_fields_;
  }

  static const ::google::protobuf::Descriptor* descriptor();
  static const S2CChatMessageNotify& default_instance();

  void Swap(S2CChatMessageNotify* other);

  // implements Message ----------------------------------------------

  S2CChatMessageNotify* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const S2CChatMessageNotify& from);
  void MergeFrom(const S2CChatMessageNotify& from);
  void Clear();
  bool IsInitialized() const;

  int ByteSize() const;
  bool MergePartialFromCodedStream(
      ::google::protobuf::io::CodedInputStream* input);
  void SerializeWithCachedSizes(
      ::google::protobuf::io::CodedOutputStream* output) const;
  ::google::protobuf::uint8* SerializeWithCachedSizesToArray(::google::protobuf::uint8* output) const;
  int GetCachedSize() const { return _cached_size_; }
  private:
  void SharedCtor();
  void SharedDtor();
  void SetCachedSize(int size) const;
  public:

  ::google::protobuf::Metadata GetMetadata() const;

  // nested types ----------------------------------------------------

  // accessors -------------------------------------------------------

  // required int32 chat_type = 1;
  inline bool has_chat_type() const;
  inline void clear_chat_type();
  static const int kChatTypeFieldNumber = 1;
  inline ::google::protobuf::int32 chat_type() const;
  inline void set_chat_type(::google::protobuf::int32 value);

  // optional bytes chat_sender_nickname = 2;
  inline bool has_chat_sender_nickname() const;
  inline void clear_chat_sender_nickname();
  static const int kChatSenderNicknameFieldNumber = 2;
  inline const ::std::string& chat_sender_nickname() const;
  inline void set_chat_sender_nickname(const ::std::string& value);
  inline void set_chat_sender_nickname(const char* value);
  inline void set_chat_sender_nickname(const void* value, size_t size);
  inline ::std::string* mutable_chat_sender_nickname();
  inline ::std::string* release_chat_sender_nickname();
  inline void set_allocated_chat_sender_nickname(::std::string* chat_sender_nickname);

  // optional uint64 chat_sender_guid = 3;
  inline bool has_chat_sender_guid() const;
  inline void clear_chat_sender_guid();
  static const int kChatSenderGuidFieldNumber = 3;
  inline ::google::protobuf::uint64 chat_sender_guid() const;
  inline void set_chat_sender_guid(::google::protobuf::uint64 value);

  // required bytes chat_content = 4;
  inline bool has_chat_content() const;
  inline void clear_chat_content();
  static const int kChatContentFieldNumber = 4;
  inline const ::std::string& chat_content() const;
  inline void set_chat_content(const ::std::string& value);
  inline void set_chat_content(const char* value);
  inline void set_chat_content(const void* value, size_t size);
  inline ::std::string* mutable_chat_content();
  inline ::std::string* release_chat_content();
  inline void set_allocated_chat_content(::std::string* chat_content);

  // @@protoc_insertion_point(class_scope:Protocol.S2CChatMessageNotify)
 private:
  inline void set_has_chat_type();
  inline void clear_has_chat_type();
  inline void set_has_chat_sender_nickname();
  inline void clear_has_chat_sender_nickname();
  inline void set_has_chat_sender_guid();
  inline void clear_has_chat_sender_guid();
  inline void set_has_chat_content();
  inline void clear_has_chat_content();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::std::string* chat_sender_nickname_;
  ::google::protobuf::uint64 chat_sender_guid_;
  ::std::string* chat_content_;
  ::google::protobuf::int32 chat_type_;

  mutable int _cached_size_;
  ::google::protobuf::uint32 _has_bits_[(4 + 31) / 32];

  friend void  protobuf_AddDesc_20001_5fS2CChatMessageNotify_2eproto();
  friend void protobuf_AssignDesc_20001_5fS2CChatMessageNotify_2eproto();
  friend void protobuf_ShutdownFile_20001_5fS2CChatMessageNotify_2eproto();

  void InitAsDefaultInstance();
  static S2CChatMessageNotify* default_instance_;
};
// ===================================================================


// ===================================================================

// S2CChatMessageNotify

// required int32 chat_type = 1;
inline bool S2CChatMessageNotify::has_chat_type() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void S2CChatMessageNotify::set_has_chat_type() {
  _has_bits_[0] |= 0x00000001u;
}
inline void S2CChatMessageNotify::clear_has_chat_type() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void S2CChatMessageNotify::clear_chat_type() {
  chat_type_ = 0;
  clear_has_chat_type();
}
inline ::google::protobuf::int32 S2CChatMessageNotify::chat_type() const {
  return chat_type_;
}
inline void S2CChatMessageNotify::set_chat_type(::google::protobuf::int32 value) {
  set_has_chat_type();
  chat_type_ = value;
}

// optional bytes chat_sender_nickname = 2;
inline bool S2CChatMessageNotify::has_chat_sender_nickname() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void S2CChatMessageNotify::set_has_chat_sender_nickname() {
  _has_bits_[0] |= 0x00000002u;
}
inline void S2CChatMessageNotify::clear_has_chat_sender_nickname() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void S2CChatMessageNotify::clear_chat_sender_nickname() {
  if (chat_sender_nickname_ != &::google::protobuf::internal::kEmptyString) {
    chat_sender_nickname_->clear();
  }
  clear_has_chat_sender_nickname();
}
inline const ::std::string& S2CChatMessageNotify::chat_sender_nickname() const {
  return *chat_sender_nickname_;
}
inline void S2CChatMessageNotify::set_chat_sender_nickname(const ::std::string& value) {
  set_has_chat_sender_nickname();
  if (chat_sender_nickname_ == &::google::protobuf::internal::kEmptyString) {
    chat_sender_nickname_ = new ::std::string;
  }
  chat_sender_nickname_->assign(value);
}
inline void S2CChatMessageNotify::set_chat_sender_nickname(const char* value) {
  set_has_chat_sender_nickname();
  if (chat_sender_nickname_ == &::google::protobuf::internal::kEmptyString) {
    chat_sender_nickname_ = new ::std::string;
  }
  chat_sender_nickname_->assign(value);
}
inline void S2CChatMessageNotify::set_chat_sender_nickname(const void* value, size_t size) {
  set_has_chat_sender_nickname();
  if (chat_sender_nickname_ == &::google::protobuf::internal::kEmptyString) {
    chat_sender_nickname_ = new ::std::string;
  }
  chat_sender_nickname_->assign(reinterpret_cast<const char*>(value), size);
}
inline ::std::string* S2CChatMessageNotify::mutable_chat_sender_nickname() {
  set_has_chat_sender_nickname();
  if (chat_sender_nickname_ == &::google::protobuf::internal::kEmptyString) {
    chat_sender_nickname_ = new ::std::string;
  }
  return chat_sender_nickname_;
}
inline ::std::string* S2CChatMessageNotify::release_chat_sender_nickname() {
  clear_has_chat_sender_nickname();
  if (chat_sender_nickname_ == &::google::protobuf::internal::kEmptyString) {
    return NULL;
  } else {
    ::std::string* temp = chat_sender_nickname_;
    chat_sender_nickname_ = const_cast< ::std::string*>(&::google::protobuf::internal::kEmptyString);
    return temp;
  }
}
inline void S2CChatMessageNotify::set_allocated_chat_sender_nickname(::std::string* chat_sender_nickname) {
  if (chat_sender_nickname_ != &::google::protobuf::internal::kEmptyString) {
    delete chat_sender_nickname_;
  }
  if (chat_sender_nickname) {
    set_has_chat_sender_nickname();
    chat_sender_nickname_ = chat_sender_nickname;
  } else {
    clear_has_chat_sender_nickname();
    chat_sender_nickname_ = const_cast< ::std::string*>(&::google::protobuf::internal::kEmptyString);
  }
}

// optional uint64 chat_sender_guid = 3;
inline bool S2CChatMessageNotify::has_chat_sender_guid() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void S2CChatMessageNotify::set_has_chat_sender_guid() {
  _has_bits_[0] |= 0x00000004u;
}
inline void S2CChatMessageNotify::clear_has_chat_sender_guid() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void S2CChatMessageNotify::clear_chat_sender_guid() {
  chat_sender_guid_ = GOOGLE_ULONGLONG(0);
  clear_has_chat_sender_guid();
}
inline ::google::protobuf::uint64 S2CChatMessageNotify::chat_sender_guid() const {
  return chat_sender_guid_;
}
inline void S2CChatMessageNotify::set_chat_sender_guid(::google::protobuf::uint64 value) {
  set_has_chat_sender_guid();
  chat_sender_guid_ = value;
}

// required bytes chat_content = 4;
inline bool S2CChatMessageNotify::has_chat_content() const {
  return (_has_bits_[0] & 0x00000008u) != 0;
}
inline void S2CChatMessageNotify::set_has_chat_content() {
  _has_bits_[0] |= 0x00000008u;
}
inline void S2CChatMessageNotify::clear_has_chat_content() {
  _has_bits_[0] &= ~0x00000008u;
}
inline void S2CChatMessageNotify::clear_chat_content() {
  if (chat_content_ != &::google::protobuf::internal::kEmptyString) {
    chat_content_->clear();
  }
  clear_has_chat_content();
}
inline const ::std::string& S2CChatMessageNotify::chat_content() const {
  return *chat_content_;
}
inline void S2CChatMessageNotify::set_chat_content(const ::std::string& value) {
  set_has_chat_content();
  if (chat_content_ == &::google::protobuf::internal::kEmptyString) {
    chat_content_ = new ::std::string;
  }
  chat_content_->assign(value);
}
inline void S2CChatMessageNotify::set_chat_content(const char* value) {
  set_has_chat_content();
  if (chat_content_ == &::google::protobuf::internal::kEmptyString) {
    chat_content_ = new ::std::string;
  }
  chat_content_->assign(value);
}
inline void S2CChatMessageNotify::set_chat_content(const void* value, size_t size) {
  set_has_chat_content();
  if (chat_content_ == &::google::protobuf::internal::kEmptyString) {
    chat_content_ = new ::std::string;
  }
  chat_content_->assign(reinterpret_cast<const char*>(value), size);
}
inline ::std::string* S2CChatMessageNotify::mutable_chat_content() {
  set_has_chat_content();
  if (chat_content_ == &::google::protobuf::internal::kEmptyString) {
    chat_content_ = new ::std::string;
  }
  return chat_content_;
}
inline ::std::string* S2CChatMessageNotify::release_chat_content() {
  clear_has_chat_content();
  if (chat_content_ == &::google::protobuf::internal::kEmptyString) {
    return NULL;
  } else {
    ::std::string* temp = chat_content_;
    chat_content_ = const_cast< ::std::string*>(&::google::protobuf::internal::kEmptyString);
    return temp;
  }
}
inline void S2CChatMessageNotify::set_allocated_chat_content(::std::string* chat_content) {
  if (chat_content_ != &::google::protobuf::internal::kEmptyString) {
    delete chat_content_;
  }
  if (chat_content) {
    set_has_chat_content();
    chat_content_ = chat_content;
  } else {
    clear_has_chat_content();
    chat_content_ = const_cast< ::std::string*>(&::google::protobuf::internal::kEmptyString);
  }
}


// @@protoc_insertion_point(namespace_scope)

}  // namespace Protocol

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_20001_5fS2CChatMessageNotify_2eproto__INCLUDED
