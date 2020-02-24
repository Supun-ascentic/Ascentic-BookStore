import * as React from 'react';
import { RouteComponentProps, withRouter, Link } from 'react-router-dom';
import axios from 'axios';

import { Layout,Card,Descriptions } from 'antd';
import "antd/dist/antd.css";

const {Content,Sider} = Layout;
const {Meta} = Card;

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number,
    book: any,
    ratings: any,
    loading: false,
}

class ViewBookDetails extends React.Component<RouteComponentProps<any>, IFormState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            book: {},
            ratings:{},
            loading: false
        }
    }

    public componentDidMount(): void {
        const config = {
            headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
        };
        axios.get(`https://localhost:44359/api/Book/get_full_book_details/${this.state.id}`,config).then(data => {
            this.setState({ book: data.data });
            console.log(this.state);
        }).catch(err=>{
            this.HandleError(err);
          })
    }

    RedirectToLogin() {
        this.props.history.push("/login");
      }
  
      HandleError(err:any){
        if(err.response.status==401){
          this.RedirectToLogin();
        }
        else{
          console.log(err)
        }
      }



    public render() {
        const {  loading,book,ratings } = this.state;
        return (
            <div style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 800 }}>
               <Layout style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 800 }}>
                    <Sider style={{background: '#fff',maxWidth:900}}>
                        <div>
                            <Card
                                cover={<img alt="example" src={book.photoURL?book.photoURL:"/book-cover-placeholder.jpg"} />}
                            >
                           
                            </Card>
                        </div>
                    </Sider>
                    <Content>
                        <div style={{padding: 50}}>
                            <Descriptions title="Book Details">
                                <Descriptions.Item label="Title">{book.title}</Descriptions.Item>
                            <Descriptions.Item label="Author">
                                {book.bookAuthor && book.bookAuthor.map((authorData: any) =>
                                     <Link to={`/author-details/${authorData.author.id}`} key={authorData.author.id}>
                                         <p style={{paddingLeft:5}} >{authorData.author.name}</p>
                                     </Link>
                                     
                                )}
                            </Descriptions.Item>
                            <Descriptions.Item label="Price">{book.price}
                            </Descriptions.Item>
                            <Descriptions.Item label="Category">
                                {book.bookCategory && book.bookCategory.map((categoryData: any) =>
                                     <p style={{paddingLeft:5}} key={categoryData.category.id}>{categoryData.category.categoryName}</p>
                                )}
                            </Descriptions.Item>
                            <Descriptions.Item label="Description">
                                {book.description}
                            </Descriptions.Item>
                            </Descriptions>  
                            
                            <Link to={`book-edit/${book.id}`} >Edit</Link>
                        </div>       
                    </Content>
                </Layout>
           </div>
        )
    }
}
export default withRouter(ViewBookDetails)